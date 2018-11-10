using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Infrastructures;
using Infrastructures.Attributes;
using Infrastructures.Exceptions;
using Microsoft.Extensions.Logging;
using Wizard.Cinema.Application.DTOs.Response;
using Wizard.Cinema.Domain.Cinema;
using Wizard.Cinema.Domain.Cinema.EnumTypes;
using Wizard.Cinema.Domain.Wizard;
using Wizard.Cinema.QueryServices;
using Wizard.Cinema.QueryServices.DTOs.Cinema;

namespace Wizard.Cinema.Application.Services
{
    [Service]
    public class SeatService : ISeatService
    {
        private readonly ISeatQueryService _seatQueryService;
        private readonly ISeatRepository _seatRepository;
        private readonly IWizardRepository _wizardRepository;
        private readonly ISelectSeatTaskRepository _selectSeatTaskRepository;

        private readonly ITransactionRepository _transactionRepository;

        private readonly ILogger<SeatService> _logger;

        public SeatService(ISeatQueryService seatQueryService, ISeatRepository seatRepository, ILogger<SeatService> logger, IWizardRepository wizardRepository, ISelectSeatTaskRepository selectSeatTaskRepository, ITransactionRepository transactionRepository)
        {
            this._seatQueryService = seatQueryService;
            this._seatRepository = seatRepository;
            this._logger = logger;
            this._wizardRepository = wizardRepository;
            this._selectSeatTaskRepository = selectSeatTaskRepository;
            this._transactionRepository = transactionRepository;
        }

        public ApiResult<bool> Select(long sessionId, long wizardId, long taskId, string[] seatNos)
        {
            try
            {
                if (sessionId <= 0)
                    return new ApiResult<bool>(ResultStatus.FAIL, "sessionId必须大于0");

                if (wizardId <= 0)
                    return new ApiResult<bool>(ResultStatus.FAIL, "wizardId须大于0");

                if (taskId <= 0)
                    return new ApiResult<bool>(ResultStatus.FAIL, "taskId必须大于0");

                Wizards wizard = _wizardRepository.Query(wizardId);
                if (wizard == null)
                    return new ApiResult<bool>(ResultStatus.FAIL, "巫师未注册");

                SelectSeatTask selectedTask = _selectSeatTaskRepository.Query(taskId);
                if (selectedTask == null)
                    return new ApiResult<bool>(ResultStatus.FAIL, "排队号不存在");

                if (selectedTask.Status != SelectTaskStatus.进行中)
                    return new ApiResult<bool>(ResultStatus.FAIL, "您的号还不能选座哦，请再等等！");

                if (selectedTask.WizardId != wizardId)
                    return new ApiResult<bool>(ResultStatus.FAIL, "请选择正确的任务");

                if (selectedTask.Total != seatNos.Length)
                    return new ApiResult<bool>(ResultStatus.FAIL, "选座数量必须为" + selectedTask.Total + "个");

                //IEnumerable<SelectSeatTask> tasks = _selectSeatTaskRepository.QueryByWizardId(sessionId, wizardId);
                //if (tasks.IsNullOrEmpty())
                //    return new ApiResult<bool>(ResultStatus.FAIL, "不在队列中");

                //SelectSeatTask canSelectTask = tasks.Where(x => x.Status == SelectTaskStatus.进行中).OrderBy(x => x.SerialNo).FirstOrDefault();
                //if (canSelectTask == null)
                //    return new ApiResult<bool>(ResultStatus.FAIL, "没有可选的名额了");

                //if (canSelectTask.Total != seatNos.Length)
                //    return new ApiResult<bool>(ResultStatus.FAIL, "选座数量必须为" + canSelectTask.Total);

                SelectSeatTask nextTask = _selectSeatTaskRepository.QueryNextTask(selectedTask);

                IEnumerable<Seat> seats = _seatRepository.Query(sessionId, seatNos);
                if (seats.Count() != seatNos.Length)
                    return new ApiResult<bool>(ResultStatus.FAIL, "seatNos传参错误");

                var selectedSeats = seats.Select(item =>
                {
                    item.Choose(wizard);
                    return item;
                }).ToList();
                selectedTask.Select(seatNos);
                nextTask?.Begin();

                _transactionRepository.UseTransaction(IsolationLevel.ReadUncommitted, () =>
                {
                    if (_seatRepository.BatchUpdate(selectedSeats.ToArray()) < 0)
                        throw new DomainException("保存时异常0");

                    if (_selectSeatTaskRepository.Select(selectedTask) < 0)
                        throw new DomainException("保存时异常1");

                    if (nextTask != null && _selectSeatTaskRepository.Start(nextTask) < 0)
                        throw new DomainException("保存时异常2");
                });

                return new ApiResult<bool>(ResultStatus.SUCCESS, true);
            }
            catch (Exception ex)
            {
                _logger.LogError("选择座位异常", ex);
                return new ApiResult<bool>(ResultStatus.EXCEPTION, ex.Message);
            }
        }

        public ApiResult<string[]> GetSeats(long sessionId, long wizardId)
        {
            try
            {
                if (sessionId <= 0)
                    return new ApiResult<string[]>(ResultStatus.FAIL, "sessionId必须大于0");

                if (wizardId <= 0)
                    return new ApiResult<string[]>(ResultStatus.FAIL, "wizardId须大于0");

                IEnumerable<string> seatNos = _seatQueryService.QuerySeatNos(sessionId, wizardId);

                return new ApiResult<string[]>(ResultStatus.SUCCESS, seatNos.ToArray());
            }
            catch (Exception ex)
            {
                _logger.LogError("查询场次座位SeatNos异常", ex);
                return new ApiResult<string[]>(ResultStatus.EXCEPTION, ex.Message);
            }
        }

        public ApiResult<IEnumerable<SeatResp>> GetBySession(long sessionId)
        {
            try
            {
                if (sessionId <= 0)
                    return new ApiResult<IEnumerable<SeatResp>>(ResultStatus.FAIL, "id不正确");

                IEnumerable<SeatInfo> seats = _seatQueryService.QueryBySessionId(sessionId);

                return new ApiResult<IEnumerable<SeatResp>>(ResultStatus.SUCCESS, Mapper.Map<SeatInfo, SeatResp>(seats));
            }
            catch (Exception ex)
            {
                _logger.LogError("查询场次座位列表异常", ex);
                return new ApiResult<IEnumerable<SeatResp>>(ResultStatus.EXCEPTION, ex.Message);
            }
        }

        public ApiResult<IEnumerable<SeatResp>> GetByActivity(long activityId)
        {
            try
            {
                if (activityId <= 0)
                    return new ApiResult<IEnumerable<SeatResp>>(ResultStatus.FAIL, "id不正确");

                IEnumerable<SeatInfo> seats = _seatQueryService.QueryByActivityId(activityId);

                return new ApiResult<IEnumerable<SeatResp>>(ResultStatus.SUCCESS, Mapper.Map<SeatInfo, SeatResp>(seats));
            }
            catch (Exception ex)
            {
                _logger.LogError("查询活动座位列表异常", ex);
                return new ApiResult<IEnumerable<SeatResp>>(ResultStatus.EXCEPTION, ex.Message);
            }
        }
    }
}
