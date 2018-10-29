using System;
using System.Text;
using Infrastructures.Encrypt;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Wizard.Cinema.Web.Options;

namespace Wizard.Cinema.Web.Extensions
{
    public static class JwtAuthenticationExtensions
    {
        public static void AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            // jwt wire up Get options from app settings
            IConfigurationSection jwtOptions = configuration.GetSection(nameof(JwtIssuerOptions));

            string secret = jwtOptions["Secret"];
            string issuer = jwtOptions[nameof(JwtIssuerOptions.Issuer)];
            string audience = jwtOptions[nameof(JwtIssuerOptions.Audience)];
            (SecurityKey signingKey, SigningCredentials credentials) = GenerateSecurityKeys(secret);

            services.Configure<JwtIssuerOptions>(options =>
            {
                options.Issuer = issuer;
                options.Audience = audience;
                options.SigningCredentials = credentials;
            });

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(configureOptions =>
            {
                configureOptions.ClaimsIssuer = issuer;
                configureOptions.SaveToken = true;

                configureOptions.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = issuer,

                    ValidateAudience = true,
                    ValidAudience = audience,

                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = signingKey,

                    RequireExpirationTime = false,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });
        }

        private static (SecurityKey, SigningCredentials) GenerateSecurityKeys(string secret)
        {
            SecurityKey signingKey;
            if (!string.IsNullOrEmpty(secret))
            {
                signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secret));
                return (signingKey, new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256Signature));
            }

            signingKey = new RsaSecurityKey(EncryptProvider.GenerateParameters());
            return (signingKey, new SigningCredentials(signingKey, SecurityAlgorithms.RsaSha256));
        }
    }
}
