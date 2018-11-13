using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Infrastructures;
using Infrastructures.Attributes;
using Wizard.Cinema.Application.DTOs.Request.Session;
using Wizard.Cinema.Application.DTOs.Response;
using Wizard.Cinema.Domain.Cinema;
using Wizard.Cinema.Domain.Cinema.EnumTypes;
using Wizard.Cinema.Domain.Movie;
using Wizard.Cinema.QueryServices;
using Wizard.Cinema.QueryServices.DTOs.Cinema;
using Wizard.Cinema.QueryServices.DTOs.Sessions;

namespace Wizard.Cinema.Application.Services
{
    [Service]
    public class SelectSeatTaskService : ISelectSeatTaskService
    {
        private readonly ISelectSeatTaskQueryService _seatTaskQueryService;
        private readonly ISelectSeatTaskRepository _selectSeatTaskRepository;
        private readonly ISessionRepository _sessionRepository;
        private readonly ITransactionRepository _transactionRepository;

        public SelectSeatTaskService(ISelectSeatTaskQueryService seatTaskQueryService,
            ISelectSeatTaskRepository selectSeatTaskRepository, ISessionRepository sessionRepository, ITransactionRepository transactionRepository)
        {
            this._seatTaskQueryService = seatTaskQueryService;
            this._selectSeatTaskRepository = selectSeatTaskRepository;
            this._sessionRepository = sessionRepository;
            this._transactionRepository = transactionRepository;
        }

        public ApiResult<bool> CheckIn(long wizardId, long sessionId)
        {
            Session session = _sessionRepository.Query(sessionId);
            if (session == null)
                return new ApiResult<bool>(ResultStatus.SUCCESS, "场次不存在");

            if (session.Status != SessionStatus.进行中)
                return new ApiResult<bool>(ResultStatus.FAIL, "场次" + session.Status.GetName());

            IEnumerable<SelectSeatTask> tasks = _selectSeatTaskRepository.QueryByWizardId(sessionId, wizardId);
            if (tasks.IsNullOrEmpty())
                return new ApiResult<bool>(ResultStatus.FAIL, "你不在排队中，请联系管理员");

            IEnumerable<SelectSeatTask> notInQueueTasks = tasks.Where(x => x.Status == SelectTaskStatus.未排队);

            IEnumerable<SelectSeatTask> overdueTasks = tasks.Where(x => x.Status == SelectTaskStatus.超时未重排);

            //if (notInQueueTasks.IsNullOrEmpty() && overdueTasks.IsNullOrEmpty())
            //    return new ApiResult<bool>(ResultStatus.FAIL, wipTask == null ? "全部都选完了" : "已经可以选了");

            //如果有未排队
            if (notInQueueTasks.Any())
            {
                var checkedInTasks = notInQueueTasks.Select(task =>
                {
                    task.CheckIn();
                    return task;
                }).ToList();
                _selectSeatTaskRepository.CheckIn(checkedInTasks);
            }

            SelectSeatTask current = _selectSeatTaskRepository.QueryCurrent(sessionId)
                                     ?? _selectSeatTaskRepository.QuerySessionNextTask(sessionId);

            //有超时的任务，重新插入并排队
            if (overdueTasks.Any())
            {
                IEnumerable<SelectSeatTask> newTasks = overdueTasks.Select(x =>
                {
                    var newTask = new SelectSeatTask(NewId.GenerateId(), x, (current ?? x).SerialNo);
                    newTask.CheckIn();
                    return newTask;
                }).ToList();

                IEnumerable<SelectSeatTask> oldTasks = overdueTasks.Select(x =>
                {
                    x.CheckInAgain();
                    return x;
                }).ToList();

                _selectSeatTaskRepository.BatchInsert(newTasks);
                _selectSeatTaskRepository.CheckInAgain(oldTasks);
            }

            if (current == null)
            {
                SelectSeatTask task = _selectSeatTaskRepository.QuerySessionNextTask(sessionId);
                task?.Begin();
                if (task != null)
                    _selectSeatTaskRepository.Start(task);
            }
            else if (current.WizardId == wizardId && current.Status != SelectTaskStatus.进行中)
            {
                current.Begin();
                _selectSeatTaskRepository.Start(current);
            }

            return new ApiResult<bool>(ResultStatus.SUCCESS, true);
        }

        public ApiResult<bool> SetOverdue(long sessionId, long taskId)
        {
            SelectSeatTask task = _selectSeatTaskRepository.Query(taskId);
            if (task == null)
                return new ApiResult<bool>(ResultStatus.FAIL, "任务不存在");

            if (task.SessionId != sessionId)
                return new ApiResult<bool>(ResultStatus.FAIL, "场次与任务不对应");

            task.Timedout();

            SelectSeatTask nextTask = _selectSeatTaskRepository.QueryNextTask(task);
            nextTask?.Begin();

            _transactionRepository.UseTransaction(IsolationLevel.ReadCommitted, () =>
            {
                if (nextTask != null && _selectSeatTaskRepository.Start(nextTask) <= 0)
                    throw new Exception("保存时异常0");

                if (_selectSeatTaskRepository.SetTimeout(task) <= 0)
                    throw new Exception("保存时异常1");
            });

            return new ApiResult<bool>(ResultStatus.SUCCESS, true);
        }

        public ApiResult<PagedData<SelectSeatTaskResp>> Search(SearchSelectSeatTaskReqs request)
        {
            SearchSelectSeatTaskCondition condition = Mapper.Map<SearchSelectSeatTaskReqs, SearchSelectSeatTaskCondition>(request);
            PagedData<SelectSeatTaskInfo> tasks = _seatTaskQueryService.QueryPaged(condition);

            return new ApiResult<PagedData<SelectSeatTaskResp>>(ResultStatus.SUCCESS, Mapper.Map<PagedData<SelectSeatTaskInfo>, PagedData<SelectSeatTaskResp>>(tasks));
        }

        public ApiResult<IEnumerable<SelectSeatTaskResp>> GetByWizardId(long sessionId, long wizardId)
        {
            IEnumerable<SelectSeatTaskInfo> tasks = _seatTaskQueryService.QueryByWizardId(sessionId, wizardId);
            return new ApiResult<IEnumerable<SelectSeatTaskResp>>(ResultStatus.SUCCESS, Mapper.Map<SelectSeatTaskInfo, SelectSeatTaskResp>(tasks));
        }

        public ApiResult<IEnumerable<SelectSeatTaskResp>> GetOverdueTask(IEnumerable<long> sessionIds, DateTime overdueTime)
        {
            IEnumerable<SelectSeatTaskInfo> tasks = _seatTaskQueryService.QueryByOverdueBeginTime(sessionIds, DTOs.EnumTypes.SelectTaskStatus.进行中, overdueTime);
            return new ApiResult<IEnumerable<SelectSeatTaskResp>>(ResultStatus.SUCCESS, Mapper.Map<SelectSeatTaskInfo, SelectSeatTaskResp>(tasks));
        }
    }
}
