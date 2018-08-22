using System.Linq;
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
    }
}
