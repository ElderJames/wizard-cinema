using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Wizard.Cinema.Admin.Helpers;
using Wizard.Cinema.Admin.Models;

namespace Wizard.Cinema.Admin.Auth
{
    public class JwtFactory : IJwtFactory
    {
        private readonly JwtIssuerOptions _jwtOptions;

        public JwtFactory(IOptions<JwtIssuerOptions> jwtOptions)
        {
            _jwtOptions = jwtOptions.Value;
            ThrowIfInvalidOptions(_jwtOptions);
        }

        public string GenerateEncodedToken(string userName, ClaimsIdentity identity)
        {
            var claims = new[]
            {
                 new Claim(JwtRegisteredClaimNames.Sub, userName),
                 new Claim(JwtRegisteredClaimNames.Jti,  _jwtOptions.JtiGenerator()),
                 new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(_jwtOptions.IssuedAt).ToString(), ClaimValueTypes.Integer64),
                 identity.FindFirst(Constants.Strings.JwtClaimIdentifiers.Rol),
                 identity.FindFirst(Constants.Strings.JwtClaimIdentifiers.Id)
            };

            identity.AddClaims(claims);

            //// Create the JWT security token and encode it.
            //var jwt = new JwtSecurityToken(
            //    issuer: _jwtOptions.Issuer,
            //    audience: _jwtOptions.Audience,
            //    claims: claims,
            //    notBefore: _jwtOptions.NotBefore,
            //    expires: _jwtOptions.Expiration,
            //    signingCredentials: _jwtOptions.SigningCredentials);

            //var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var handler = new JwtSecurityTokenHandler();

            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _jwtOptions.Issuer,
                Audience = _jwtOptions.Audience,
                SigningCredentials = _jwtOptions.SigningCredentials,
                Subject = identity,
                Expires = _jwtOptions.Expiration,
            });

            var encodedJwt = handler.WriteToken(securityToken);

            return encodedJwt;
        }

        public ClaimsIdentity GenerateClaimsIdentity(string userName, long userId)
        {
            return new ClaimsIdentity(new GenericIdentity(userName, "Token"), new[]
            {
                new Claim(Constants.Strings.JwtClaimIdentifiers.Id, userId.ToString()),
                new Claim(Constants.Strings.JwtClaimIdentifiers.Rol, Constants.Strings.JwtClaims.ApiAccess),
                new Claim(ClaimTypes.Name, userName)
            });
        }

        /// <returns>Date converted to seconds since Unix epoch (Jan 1, 1970, midnight UTC).</returns>
        private static long ToUnixEpochDate(DateTime date)
            => (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);

        private static void ThrowIfInvalidOptions(JwtIssuerOptions options)
        {
            if (options == null) throw new ArgumentNullException(nameof(options));

            if (options.ValidFor <= TimeSpan.Zero)
            {
                throw new ArgumentException("Must be a non-zero TimeSpan.", nameof(JwtIssuerOptions.ValidFor));
            }

            if (options.SigningCredentials == null)
            {
                throw new ArgumentNullException(nameof(JwtIssuerOptions.SigningCredentials));
            }

            if (options.JtiGenerator == null)
            {
                throw new ArgumentNullException(nameof(JwtIssuerOptions.JtiGenerator));
            }
        }
    }
}
