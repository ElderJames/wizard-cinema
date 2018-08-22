using System.Security.Claims;
using System.Security.Principal;

namespace Wizard.Cinema.Admin.Helpers
{
    public class CurrentUser
    {
        public long UserId { get; }

        public string UserName { get; }

        public CurrentUser(IIdentity identity)
        {
            if (identity is ClaimsIdentity claimsIdentity)
            {
                UserName = claimsIdentity.Name;
                UserId = long.TryParse(claimsIdentity.FindFirst(x => x.Type == Constants.Strings.JwtClaimIdentifiers.Id)?.Value, out long userId) && userId > 0
                    ? userId : 0;
            }
        }
    }
}
