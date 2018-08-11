using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Wizard.Cinema.Admin.Auth;
using Wizard.Cinema.Admin.Models;

namespace Wizard.Cinema.Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : BaseController
    {
        private readonly JwtIssuerOptions _jwtOptions;
        private readonly IJwtFactory _jwtFactory;

        public AccountController(IJwtFactory jwtFactory, IOptions<JwtIssuerOptions> jwtOptions)
        {
            this._jwtOptions = jwtOptions.Value;
            this._jwtFactory = jwtFactory;
        }

        // POST api/accounts
        [HttpPost("sign-up")]
        public IActionResult Register([FromBody]User model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var identity = _jwtFactory.GenerateClaimsIdentity(model.Username, model.ID.ToString());

            return Ok(new
            {
                id = identity.Claims.Single(c => c.Type == "id").Value,
                auth_token = _jwtFactory.GenerateEncodedToken(model.Username, identity),
                expires_in = (int)_jwtOptions.ValidFor.TotalSeconds
            });
        }
    }
}