﻿using System.Collections.Generic;
using System.Linq;
using Tweetinvi.Models;
using Tweetinvi;
using DataAccess.Credentials;

namespace DataAccess.Repositories.Users
{
    internal class FavoriteUserRepository : IFavoriteUserRepository
    {
        private ITwitterCredentials credentials;

        public FavoriteUserRepository(ITwitterCredentialsFactory credentialsFactory)
        {
            this.credentials = credentialsFactory.Create();
        }

        public IEnumerable<DataAccess.Entities.User> GetAll()
        {
            var authenticatedUser = User.GetAuthenticatedUser(this.credentials);
            var users = Auth.ExecuteOperationWithCredentials(
                this.credentials, () => authenticatedUser.GetFriends());
            
            // TODO: add mapper;

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

        public void UpdateDeviceNotificationsStatus(string screenName, bool deviceNotificationsEnabled)
        {
            var authenticatedUser = User.GetAuthenticatedUser(this.credentials);

            var relationship = authenticatedUser.GetRelationshipWith(screenName);

            authenticatedUser.UpdateRelationshipAuthorizationsWith(
                screenName, relationship.WantRetweets, deviceNotificationsEnabled);
        }
    }
}
