using System.Linq;
using System.Security.Claims;
using System.Web;

namespace TwitterBackup.Infrastructure.Identity.Claims
{
    public class TwitterClaimsHelper : ITwitterClaimsHelper
    {
        public string GetOAuthAccessToken()
        {
            return GetClaimValue("urn:tokens:twitter:accesstoken");
        }

        public string GetOAuthAccessTokenSecret()
        {
            return GetClaimValue("urn:tokens:twitter:accesstokensecret");
        }

        public string GetUserId()
        {
            return GetClaimValue("urn:tokens:twitter:userid");
        }

        private static string GetClaimValue(string claimName)
        {
            var principal = HttpContext.Current.User as ClaimsPrincipal;

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