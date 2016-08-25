using System.Web.Configuration;
using TwitterBackup.Infrastructure.Identity.Claims;
using Tweetinvi.Models;

namespace DataAccess.Credentials
{
    internal class TwitterCredentialsFactory : ITwitterCredentialsFactory
    {
        private readonly ITwitterClaimsHelper claimsHelper;

        public TwitterCredentialsFactory(ITwitterClaimsHelper claimsHelper)
        {
            this.claimsHelper = claimsHelper;
        }

        public ITwitterCredentials Create()
        {
            var credentials = new TwitterCredentials(
                WebConfigurationManager.AppSettings["twitter:ConsumerKey"],
                WebConfigurationManager.AppSettings["twitter:ConsumerSecret"],
                this.claimsHelper.GetOAuthAccessToken(),
                this.claimsHelper.GetOAuthAccessTokenSecret());
            return credentials;
        }
    }
}
