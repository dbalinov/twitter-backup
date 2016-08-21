﻿using Tweetinvi.Models;
using Tweetinvi;
using DataAccess.Credentials;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Users
{
    internal class FriendRepository : IFriendRepository
    {
        private ITwitterCredentials credentials;

        public FriendRepository(ITwitterCredentialsFactory credentialsFactory)
        {
            this.credentials = credentialsFactory.Create();
        }

        private Entities.User Map(IUser friend)
        {
            return new Entities.User
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

        public async Task<Entities.User> GetByScreenNameAsync(string screenName)
        {
            var user = await Auth.ExecuteOperationWithCredentials(
                this.credentials, () => UserAsync.GetUserFromScreenName(screenName));

            return Map(user);
        }
    }
}
