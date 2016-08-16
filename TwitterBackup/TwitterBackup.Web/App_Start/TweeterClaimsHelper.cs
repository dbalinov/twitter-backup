using System.Linq;
using System.Security.Claims;
using System.Threading;

namespace TwitterBackup.Web
{
    public interface ITwitterClaimsHelper
    {
        string GetOAuthAccessToken();
        string GetOAuthAccessTokenSecret();
        ulong GetUserId();
    }

    public class TweeterClaimsHelper : ITwitterClaimsHelper
    {
        public string GetOAuthAccessToken()
        {
            return GetClaimValue("urn:tokens:twitter:accesstoken");
        }

        public string GetOAuthAccessTokenSecret()
        {
            return GetClaimValue("urn:tokens:twitter:accesstokensecret");
        }

        public ulong GetUserId()
        {
            ulong userId;
            ulong.TryParse(GetClaimValue("urn:tokens:twitter:userid"), out userId);
            return userId;
        }

        private static string GetClaimValue(string claimName)
        {
            var principal = Thread.CurrentPrincipal as ClaimsPrincipal;

            if (principal == null)
            {
                return string.Empty;
            }

            var identity = principal.Identities.FirstOrDefault();

            if (identity == null)
            {
                return string.Empty;
            }

            if (!identity.IsAuthenticated)
            {
                return string.Empty;
            }

            var result = identity.Claims.Where(claim => claim.Type == claimName).Select(claim => claim.Value).FirstOrDefault();

            return result ?? string.Empty;
        }
    }
}