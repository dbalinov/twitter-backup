using Tweetinvi.Models;

namespace TwitterBackup.DataAccess.Credentials
{
    public interface ITwitterCredentialsFactory
    {
        ITwitterCredentials Create();
    }
}
