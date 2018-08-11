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

namespace Wizard.Cinema.Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        private readonly JwtIssuerOptions _jwtOptions;
        private readonly IJwtFactory _jwtFactory;

        public AuthController(IJwtFactory jwtFactory, IOptions<JwtIssuerOptions> jwtOptions)
        {
            this._jwtOptions = jwtOptions.Value;
            this._jwtFactory = jwtFactory;
        }

        [HttpPut("Login")]
        public IActionResult Login([FromBody]User user)
        {
            var identity = GetClaimsIdentity("elderjames", "12345678");
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

        private ClaimsIdentity GetClaimsIdentity(string userName, string password)
        {
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
                return null;

            // get the user to verifty
            var userToVerify = new User();

            if (userToVerify == null) return null;

            // check the credentials
            if (true)
            {
                return _jwtFactory.GenerateClaimsIdentity("elderjames", "123");
            }

            // Credentials are invalid, or account doesn't exist
            return null;
        }
    }
}