using System.Collections.Generic;
using System.Linq;
using DataAccess.Credentials;
using Tweetinvi;
using Tweetinvi.Models;

namespace DataAccess.Repositories.Users
{
    internal class UserRepository : IUserRepository
    {
        private ITwitterCredentials credentials;

        public UserRepository(ITwitterCredentialsFactory credentialsFactory)
        {
            this.credentials = credentialsFactory.Create();
        }

        public IEnumerable<Entities.User> GetUsersFromIds(IEnumerable<string> ids)
        {
            var users = Auth.ExecuteOperationWithCredentials(
                this.credentials, () => User.GetUsersFromIds(ids.Select(long.Parse)));

            return users.Select(friend => Map(friend));
        }

        private DataAccess.Entities.User Map(IUser friend)
        {
            return new DataAccess.Entities.User
            {
                Id = friend.IdStr,
                Name = friend.Name,
                Description = friend.Description,
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

    }
}
