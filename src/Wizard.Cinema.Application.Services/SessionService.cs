using System;
using System.Data;
using System.Linq;
using Infrastructures;
using Infrastructures.Attributes;
using Infrastructures.Exceptions;
using Microsoft.Extensions.Logging;
using Wizard.Cinema.Application.DTOs.Request.Session;
using Wizard.Cinema.Application.DTOs.Response;
using Wizard.Cinema.Domain.Activity;
using Wizard.Cinema.Domain.Cinema;
using Wizard.Cinema.Domain.Movie;
using Wizard.Cinema.QueryServices;
using Wizard.Cinema.QueryServices.DTOs.Cinema;

namespace Wizard.Cinema.Application.Services
{
    [Impl]
    public class SessionService : ISessionService
    {
        private readonly ILogger<SessionService> _logger;
        private readonly ISessionQueryService _sessionQueryService;
        private readonly ISessionRepository _sessionRepository;
        private readonly IActivityRepository _activityRepository;
        private readonly ISeatRepository _seatRepository;

        private readonly ITransactionRepository _transactionRepository;

        public SessionService(ILogger<SessionService> logger,
            ISessionQueryService sessionQueryService,
            ISessionRepository sessionRepository,
            ITransactionRepository transactionRepository,
            IActivityRepository activityRepository,
            ISeatRepository seatRepository)
        {
            this._logger = logger;
            this._sessionQueryService = sessionQueryService;
            this._sessionRepository = sessionRepository;
            this._transactionRepository = transactionRepository;
            this._activityRepository = activityRepository;
            this._seatRepository = seatRepository;
        }

        public ApiResult<bool> Create(CreateSessionReqs request)
        {
            try
            {
                Activity activity = _activityRepository.Query(request.ActivityId);
                if (activity == null)
                    return new ApiResult<bool>(ResultStatus.FAIL, "找不到所选的活动");

                long sessionId = NewId.GenerateId();
                var session = new Session(sessionId, activity.DivisionId, activity.ActivityId, request.CinemaId, request.HallId, request.Seats.Select(x => x.SeatNo).ToArray());

                Seat[] seats = request.Seats.Select(seatInfo =>
                {
                    long seatId = NewId.GenerateId();
                    string[] position = { seatInfo.RowId, seatInfo.ColumnId };
                    return new Seat(seatId, sessionId, activity.ActivityId, seatInfo.SeatNo, position);
                }).ToArray();

                _transactionRepository.UseTransaction(IsolationLevel.ReadUncommitted, () =>
                {
                    _seatRepository.BatchInsert(seats);

                    if (_sessionRepository.Insert(session) <= 0)
                        throw new DomainException("保存时异常,请稍后再试");
                });

                return new ApiResult<bool>(ResultStatus.SUCCESS, true);
            }
            catch (Exception ex)
            {
                _logger.LogError("创建场次时异常", ex);
                return new ApiResult<bool>(ResultStatus.EXCEPTION, ex.Message);
            }
        }

        public ApiResult<bool> Change(UpdateSessionReqs request)
        {
            try
            {
                Session session = _sessionRepository.Query(request.SessionId);
                if (session == null)
                    return new ApiResult<bool>(ResultStatus.FAIL, "找不到这个场次了");

                session.Change(request.CinemaId, request.HallId, request.SeatNos);
                if (_sessionRepository.Update(session) <= 0)
                    return new ApiResult<bool>(ResultStatus.FAIL, "保存时出错，请稍后再试");

                return new ApiResult<bool>(ResultStatus.SUCCESS, true);
            }
            catch (Exception ex)
            {
                _logger.LogError("更新场次时异常", ex);
                return new ApiResult<bool>(ResultStatus.EXCEPTION, ex.Message);
            }
        }

        public ApiResult<SessionResp> GetSession(long sessionId)
        {
            try
            {
                SessionInfo session = _sessionQueryService.Query(sessionId);
                if (session == null)
                    return new ApiResult<SessionResp>(ResultStatus.FAIL, "所选场次不存在");

                return new ApiResult<SessionResp>(ResultStatus.SUCCESS, Mapper.Map<SessionInfo, SessionResp>(session));
            }
            catch (Exception ex)
            {
                _logger.LogError("查询场次时异常", ex);
                return new ApiResult<SessionResp>(ResultStatus.EXCEPTION, ex.Message);
            }
        }

        public ApiResult<PagedData<SessionResp>> SearchSession(SearchSessionReqs search)
        {
            try
            {
                PagedData<SessionInfo> sessions = _sessionQueryService.QueryPaged(Mapper.Map<SearchSessionReqs, SearchSessionCondition>(search));
                return new ApiResult<PagedData<SessionResp>>(ResultStatus.SUCCESS, Mapper.Map<PagedData<SessionInfo>, PagedData<SessionResp>>(sessions));
            }
            catch (Exception ex)
            {
                _logger.LogError("查询场次时异常", ex);
                return new ApiResult<PagedData<SessionResp>>(ResultStatus.EXCEPTION, new PagedData<SessionResp>(), ex.Message);
            }
        }
    }
}
