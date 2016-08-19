using System.Collections.Generic;
using System.Linq;
using Tweetinvi.Models;
using Tweetinvi;
using DataAccess.Credentials;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Users
{
    internal class FavoriteUserRepository : IFavoriteUserRepository
    {
        private ITwitterCredentials credentials;

        public FavoriteUserRepository(ITwitterCredentialsFactory credentialsFactory)
        {
            this.credentials = credentialsFactory.Create();
        }

        public async Task<IEnumerable<DataAccess.Entities.User>> GetAllAsync()
        {
            var authenticatedUser = User.GetAuthenticatedUser(this.credentials);

            var users = await ( Auth.ExecuteOperationWithCredentials(
                this.credentials, () => authenticatedUser.GetFriendsAsync()));

            return users.Select(friend => new DataAccess.Entities.User
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
            });
        }
    }
}
