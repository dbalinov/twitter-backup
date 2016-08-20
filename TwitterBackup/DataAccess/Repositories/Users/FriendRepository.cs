using System.Collections.Generic;
using System.Linq;
using Tweetinvi.Models;
using Tweetinvi;
using DataAccess.Credentials;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;

namespace DataAccess.Repositories.Users
{
    internal class FriendRepository : IFriendRepository
    {
        private ITwitterCredentials credentials;

        public FriendRepository(ITwitterCredentialsFactory credentialsFactory)
        {
            var connectionString = "mongodb://dbalinov:n0password@ds013216.mlab.com:13216/twitter-backup";
            MongoClient client = new MongoClient(connectionString);
            IMongoDatabase database = client.GetDatabase("twitter-backup");
            var statuses = database.GetCollection<Entities.Status>("Statuses");

            this.credentials = credentialsFactory.Create();
        }

        public IEnumerable<Entities.User> GetAll()
        {
            var authenticatedUser = User.GetAuthenticatedUser(this.credentials);

            var users = Auth.ExecuteOperationWithCredentials(
                this.credentials, () => authenticatedUser.GetFriends());

            return users.Select(friend => Map(friend));
        }

        private DataAccess.Entities.User Map(IUser friend)
        {
            return new DataAccess.Entities.User
            {
                Id = friend.IdStr,
                Name = friend.Name,
                Description = friend.Description,
                Notifications = friend.Notifications,
                ProfileImageUrl = friend.ProfileImageUrl.Replace("_normal", "_bigger"),
                ProfileBackgroundColor = friend.ProfileBackgroundColor,
                ProfileBannerUrl = friend.ProfileBannerURL,
                FollowersCount = friend.FollowersCount,
                StatusesCount = friend.StatusesCount,
                FriendsCount = friend.FriendsCount,
                ScreenName = friend.ScreenName,
                Verified = friend.Verified
            };
        }

        public async Task<IEnumerable<DataAccess.Entities.User>> GetAllAsync()
        {
            var authenticatedUser = User.GetAuthenticatedUser(this.credentials);

            var users = await Auth.ExecuteOperationWithCredentials(
                this.credentials, () => authenticatedUser.GetFriendsAsync());

            return users.Select(friend => Map(friend));
        }
    }
}
