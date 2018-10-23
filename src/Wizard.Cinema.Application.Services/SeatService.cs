using System;
using System.Collections.Generic;
using System.Linq;
using Infrastructures;
using Infrastructures.Attributes;
using Microsoft.Extensions.Logging;
using Wizard.Cinema.Application.DTOs.Response;
using Wizard.Cinema.Domain.Cinema;
using Wizard.Cinema.Domain.Wizard;
using Wizard.Cinema.QueryServices;
using Wizard.Cinema.QueryServices.DTOs.Cinema;

namespace Wizard.Cinema.Application.Services
{
    [Impl]
    public class SeatService : ISeatService
    {
        private readonly ISeatQueryService _seatQueryService;
        private readonly ISeatRepository _seatRepository;
        private readonly IWizardRepository _wizardRepository;
        private readonly ILogger<SeatService> _logger;

        public SeatService(ISeatQueryService seatQueryService, ISeatRepository seatRepository, ILogger<SeatService> logger, IWizardRepository wizardRepository)
        {
            this._seatQueryService = seatQueryService;
            this._seatRepository = seatRepository;
            this._logger = logger;
            this._wizardRepository = wizardRepository;
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

                IEnumerable<Seat> seats = _seatRepository.Query(sessionId, seatNos);
                if (seats.Count() != seatNos.Length)
                    return new ApiResult<bool>(ResultStatus.FAIL, "seatNos传参错误");

                seats.ForEach(item => item.Choose(wizard));

                _seatRepository.BatchUpdate(seats.ToArray());

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

                string[] seatNos = _seatQueryService.QuerySeatNos(sessionId, wizardId);

                return new ApiResult<string[]>(ResultStatus.SUCCESS, seatNos);
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
