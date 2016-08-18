using Tweetinvi.Models;

namespace DataAccess.Credentials
{
    public interface ITwitterCredentialsFactory
    {
        ITwitterCredentials Create();
    }
}
