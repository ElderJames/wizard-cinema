using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using Infrastructures;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Wizard.Cinema.Web.Models;
using Wizard.Cinema.Web.Options;

namespace Wizard.Cinema.Web.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly JwtIssuerOptions _jwtOptions;

        public AccountController(IOptionsSnapshot<JwtIssuerOptions> jwtOptions)
        {
            this._jwtOptions = jwtOptions.Value;
        }

        [HttpPost("signin")]
        public IActionResult Signin(SigninModel model)
        {
            var identity = new ClaimsIdentity(new GenericIdentity(model.Mobile, "Token"), new[]
            {
                new Claim("id","123" ),
                new Claim("rol", "api_access"),
                new Claim(ClaimTypes.Name, model.Mobile),
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
