using DataAccess.Entities;

namespace Business.Models.Mapping
{
    internal class UserMapper
    {
        public UserModel Map(User from, UserModel to)
        {
            to.Id = from.Id;
            to.Name = from.Name;
            to.Description = from.Description;
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

        public DashboardUserModel Map(User from, DashboardUserModel to)
        {
            to.Id = from.Id;
            to.Name = from.Name;
            to.ProfileImageUrl = from.ProfileImageUrl;
            to.ScreenName = from.ScreenName;

            return to;
        }
    }
}
