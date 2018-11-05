using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Infrastructures;
using Infrastructures.Attributes;
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

        public ApiResult<bool> Select(long wizardId, long sessionId, string[] seatNos)
        {
            try
            {
                if (sessionId <= 0)
                    return new ApiResult<bool>(ResultStatus.FAIL, "sessionId必须大于0");

                if (wizardId <= 0)
                    return new ApiResult<bool>(ResultStatus.FAIL, "wizardId须大于0");

                Wizards wizard = _wizardRepository.Query(wizardId);
                if (wizard == null)
                    return new ApiResult<bool>(ResultStatus.FAIL, "巫师未注册");

                IEnumerable<SelectSeatTask> tasks = _selectSeatTaskRepository.QueryByWizardId(sessionId, wizardId);
                if (tasks.IsNullOrEmpty())
                    return new ApiResult<bool>(ResultStatus.FAIL, "不在队列中");

                SelectSeatTask canSelectTask = tasks.Where(x => x.Status == SelectTaskStatus.进行中).OrderBy(x => x.SerialNo).FirstOrDefault();
                if (canSelectTask == null)
                    return new ApiResult<bool>(ResultStatus.FAIL, "没有可选的名额了");

                SelectSeatTask nextTask = _selectSeatTaskRepository.QueryNextTask(sessionId, canSelectTask.SerialNo);

                IEnumerable<Seat> seats = _seatRepository.Query(sessionId, seatNos);
                if (seats.Count() != seatNos.Length)
                    return new ApiResult<bool>(ResultStatus.FAIL, "seatNos传参错误");

                seats.ForEach(item => item.Choose(wizard));
                canSelectTask.Select(seatNos);
                nextTask.Begin();

                _transactionRepository.UseTransaction(IsolationLevel.ReadUncommitted, () =>
                {
                    _seatRepository.BatchUpdate(seats.ToArray());
                    _selectSeatTaskRepository.Select(canSelectTask);
                    _selectSeatTaskRepository.Start(nextTask);
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
