using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace Wizard.Cinema.Web.Extensions
{
    public static class HttpContextExtensions
    {
        public static bool IsAuthenticated(this HttpContext httpContext)
        {
            return IsAuthenticated(httpContext?.User);
        }

        public static bool IsAuthenticated(this ClaimsPrincipal claimsPrincipal)
        {
            bool? isAuthedExpr = claimsPrincipal?.Identity?.IsAuthenticated;
            return isAuthedExpr.HasValue && isAuthedExpr.Value;
        }

        public static long? ExtractUserId(this ClaimsPrincipal claimsPrincipal)
        {
            bool IsIdClaim(Claim claim)
            {
                return claim.Type == ClaimTypes.NameIdentifier;
            }

            ClaimsIdentity identity = claimsPrincipal.Identities.FirstOrDefault(id => id.HasClaim(IsIdClaim));
            string userIdClaim = identity?.Claims.FirstOrDefault(IsIdClaim)?.Value;
            if (userIdClaim == null || !long.TryParse(userIdClaim, out long userId))
            {
                return null;
            }

            return userId;
        }
    }
}
