using System;
using Infrastructures;
using Infrastructures.Attributes;
using Microsoft.Extensions.Logging;
using Wizard.Cinema.Application.DTOs.Request.Cinema;
using Wizard.Cinema.Application.DTOs.Response;
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

        public SessionService(ILogger<SessionService> logger, ISessionQueryService sessionQueryService, ISessionRepository sessionRepository)
        {
            this._logger = logger;
            this._sessionQueryService = sessionQueryService;
            this._sessionRepository = sessionRepository;
        }

        public ApiResult<bool> Create(CreateSessionReqs request)
        {
            try
            {
                long sessionId = NewId.GenerateId();
                var session = new Session(sessionId, request.SessionId, request.Cinema, request.Hall, request.Seats);
                if (_sessionRepository.Insert(session) <= 0)
                    return new ApiResult<bool>(ResultStatus.FAIL, "保存时异常,请稍后再试");

                return new ApiResult<bool>(ResultStatus.SUCCESS, true);
            }
            catch (Exception ex)
            {
                _logger.LogError("查询场次时异常", ex);
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
