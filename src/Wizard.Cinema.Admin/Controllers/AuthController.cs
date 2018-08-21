using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Wizard.Cinema.Admin.Auth;
using Wizard.Cinema.Admin.Helpers;
using Wizard.Cinema.Admin.Models;
using Wizard.Cinema.Application.Services;
using Wizard.Cinema.Application.Services.Dto.Response;
using Wizard.Cinema.Infrastructures;

namespace Wizard.Cinema.Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        private readonly JwtIssuerOptions _jwtOptions;
        private readonly IJwtFactory _jwtFactory;
        private readonly IWizardService _wizardService;

        public AuthController(IJwtFactory jwtFactory, IOptions<JwtIssuerOptions> jwtOptions, IWizardService wizardService)
        {
            this._jwtOptions = jwtOptions.Value;
            this._jwtFactory = jwtFactory;
            this._wizardService = wizardService;
        }

        [HttpPut("Login")]
        public IActionResult Login([FromBody]User user)
        {
            ClaimsIdentity identity = GetClaimsIdentity(user.Email, user.Password);
            if (identity == null)
            {
                return BadRequest(Errors.AddErrorToModelState("login_failure", "Invalid username or password.", ModelState));
            }

            return Ok(new
            {
                id = identity.Claims.Single(c => c.Type == "id").Value,
                auth_token = _jwtFactory.GenerateEncodedToken(identity.Name, identity),
                expires_in = (int)_jwtOptions.ValidFor.TotalSeconds
            });
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetUserInfo()
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;
            return Ok(new { UserName = claimsIdentity?.Name });
        }

        private ClaimsIdentity GetClaimsIdentity(string account, string password)
        {
            if (string.IsNullOrEmpty(account) || string.IsNullOrEmpty(password))
                return null;

            ApiResult<WizardResp> result = _wizardService.GetWizard(account, password);
            if (result.Status != ResultStatus.SUCCESS || result.Result == null)
                return null;

            return _jwtFactory.GenerateClaimsIdentity(result.Result.Name, result.Result.WizardId);
        }
    }
}
