using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Wizard.Cinema.Admin.Auth;
using Wizard.Cinema.Admin.Models;
using Wizard.Cinema.Application.Services;
using Wizard.Cinema.Application.Services.Dto.Request;
using Wizard.Cinema.Infrastructures;

namespace Wizard.Cinema.Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : BaseController
    {
        private readonly JwtIssuerOptions _jwtOptions;
        private readonly IJwtFactory _jwtFactory;
        private readonly IWizardService _wizardService;

        public AccountController(IJwtFactory jwtFactory, IOptions<JwtIssuerOptions> jwtOptions, IWizardService wizardService)
        {
            this._jwtOptions = jwtOptions.Value;
            this._jwtFactory = jwtFactory;
            this._wizardService = wizardService;
        }

        // POST api/accounts
        [HttpPost("sign-up")]
        public IActionResult Register([FromBody]User model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ApiResult<bool> result = _wizardService.Register(new RegisterWizardReqs()
            {
                Email = model.Email,
                Passward = model.Password
            });
            if (result.Status != ResultStatus.SUCCESS)
                return Fail(result.Message);

            return Ok();
        }
    }
}
