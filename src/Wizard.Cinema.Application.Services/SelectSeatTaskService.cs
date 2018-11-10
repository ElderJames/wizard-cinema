using System;
using System.Collections.Generic;
using System.Linq;
using Infrastructures;
using Infrastructures.Attributes;
using Wizard.Cinema.Application.DTOs.Request.Session;
using Wizard.Cinema.Application.DTOs.Response;
using Wizard.Cinema.Domain.Cinema;
using Wizard.Cinema.Domain.Cinema.EnumTypes;
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

        public SelectSeatTaskService(ISelectSeatTaskQueryService seatTaskQueryService,
            ISelectSeatTaskRepository selectSeatTaskRepository)
        {
            this._seatTaskQueryService = seatTaskQueryService;
            this._selectSeatTaskRepository = selectSeatTaskRepository;
        }

        /// <summary>
        /// 登记预约
        /// </summary>
        /// <param name="wizardId"></param>
        /// <param name="sessionId"></param>
        /// <returns></returns>
        public ApiResult<bool> CheckIn(long wizardId, long sessionId)
        {
            IEnumerable<SelectSeatTask> tasks = _selectSeatTaskRepository.QueryByWizardId(sessionId, wizardId);
            if (tasks.IsNullOrEmpty())
                return new ApiResult<bool>(ResultStatus.FAIL, "你不在排队中，请联系管理员");

            IEnumerable<SelectSeatTask> notInQueueTasks = tasks.Where(x => x.Status == SelectTaskStatus.未排队);
            SelectSeatTask wipTask = tasks.FirstOrDefault(x => x.Status == SelectTaskStatus.进行中);
            IEnumerable<SelectSeatTask> overdueTasks = tasks.Where(x => x.Status == SelectTaskStatus.超时并结束);

            if (notInQueueTasks.IsNullOrEmpty() && overdueTasks.IsNullOrEmpty())
                return new ApiResult<bool>(ResultStatus.FAIL, wipTask == null ? "全部都选完了" : "已在排队");

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

            //有超时的任务，重新插入并排队
            if (overdueTasks.Any())
            {
                SelectSeatTask current = _selectSeatTaskRepository.QueryCurrent(sessionId);
                IEnumerable<SelectSeatTask> newTasks = overdueTasks.Select(x => new SelectSeatTask(NewId.GenerateId(), x, current.SerialNo + 2));

                _selectSeatTaskRepository.BatchInsert(newTasks.ToArray());
            }

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
    }
}
