using System.Security.Claims;

namespace Wizard.Cinema.Admin.Auth
{
    public interface IJwtFactory
    {
        string GenerateEncodedToken(string userName, ClaimsIdentity identity);

        ClaimsIdentity GenerateClaimsIdentity(string userName, string id);
    }
}