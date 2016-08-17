﻿using DataAccess.Entities;

namespace Business.Models.Mapping
{
    public class UserMapper
    {
        public UserModel Map(User from, UserModel to)
        {
            to.Id = from.Id;
            to.Name = from.Name;
            to.Description = from.Description;
            to.Notifications = from.Notifications;
            to.ProfileImageUrl = from.ProfileImageUrl;
            to.Url = from.Url;
            to.ProfileBackgroundColor = from.ProfileBackgroundColor;
            to.ProfileBannerUrl = from.ProfileBannerUrl;
            to.FollowersCount = from.FollowersCount;
            to.StatusesCount = from.StatusesCount;
            to.FriendsCount = from.FriendsCount;
            to.ScreenName = from.ScreenName;
            to.Verified = from.Verified;

            return to;
        }
    }
}
