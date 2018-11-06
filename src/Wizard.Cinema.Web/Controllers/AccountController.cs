using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using Infrastructures;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Wizard.Cinema.Application.DTOs.Response;
using Wizard.Cinema.Application.Services;
using Wizard.Cinema.Application.Services.Dto.Response;
using Wizard.Cinema.Web.Models;
using Wizard.Cinema.Web.Options;

namespace Wizard.Cinema.Web.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly JwtIssuerOptions _jwtOptions;
        private readonly IActivityService _activityService;
        private readonly IWizardService _wizardService;

        public AccountController(IOptionsSnapshot<JwtIssuerOptions> jwtOptions, IActivityService activityService, IWizardService wizardService)
        {
            this._activityService = activityService;
            this._wizardService = wizardService;
            this._jwtOptions = jwtOptions.Value;
        }

        [HttpPost("signin")]
        public IActionResult Signin(SigninModel model)
        {
            if (model.Mobile != model.Password)
                return Ok(new ApiResult<object>(ResultStatus.FAIL, "手机号或者密码不正确"));

            ApiResult<WizardResp> wizardResult = _wizardService.GetWizard(model.Mobile, model.Password);
            if (wizardResult.Status != ResultStatus.SUCCESS)
                return Ok(new ApiResult<object>(ResultStatus.FAIL, "手机号或者密码不正确"));

            ApiResult<ProfileResp> wizardInfoResult = _wizardService.GetPrpfile(wizardResult.Result.WizardId);
            if (wizardResult.Status != ResultStatus.SUCCESS)
                return Ok(new ApiResult<object>(ResultStatus.FAIL, "手机号或者密码不正确"));

            ApiResult<IEnumerable<ApplicantResp>> applicatResult = _activityService.GetApplicants(model.Mobile);
            if (applicatResult.Status != ResultStatus.SUCCESS || applicatResult.Result.IsNullOrEmpty())
                return Ok(new ApiResult<object>(ResultStatus.FAIL, "未报名"));

            var identity = new ClaimsIdentity(new GenericIdentity(model.Mobile, "Token"), new[]
            {
                new Claim("id",wizardResult.Result.WizardId.ToString()),
                new Claim("rol", "api_access"),
                new Claim(ClaimTypes.NameIdentifier,wizardResult.Result.WizardId.ToString()),
                new Claim(ClaimTypes.Name,wizardInfoResult.Result.NickName),
                new Claim(JwtRegisteredClaimNames.Sub, model.Mobile),
                new Claim(JwtRegisteredClaimNames.Jti,  _jwtOptions.JtiGenerator()),
                new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(_jwtOptions.IssuedAt).ToString(), ClaimValueTypes.Integer64),
            });

            var handler = new JwtSecurityTokenHandler();

            SecurityToken securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _jwtOptions.Issuer,
                Audience = _jwtOptions.Audience,
                SigningCredentials = _jwtOptions.SigningCredentials,
                NotBefore = _jwtOptions.NotBefore,
                Subject = identity,
                Expires = _jwtOptions.Expiration,
            });

            string encodedJwt = handler.WriteToken(securityToken);

            return Ok(new ApiResult<object>(ResultStatus.SUCCESS, new
            {
                id = identity.Claims.Single(c => c.Type == "id").Value,
                auth_token = encodedJwt,
                expires_in = (int)_jwtOptions.ValidFor.TotalSeconds
            }));
        }

        [Authorize]
        [HttpGet("user")]
        public IActionResult UserInfo()
        {
            return Ok(Anonymous.ApiResult(ResultStatus.SUCCESS, new { userName = "elderjames" }));
        }

        private static long ToUnixEpochDate(DateTime date)
            => (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);
    }
}
