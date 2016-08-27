namespace TwitterBackup.DataAccess.Entities.Mapping
{
    public class UserMapper
    {
        public User Map(Tweetinvi.Models.IUser from, User to)
        {
            to.Id = from.IdStr;
            to.Name = from.Name;
            to.Description = from.Description;
            to.ProfileImageUrl = from.ProfileImageUrl;

            if (to.ProfileImageUrl != null)
            {
                to.ProfileImageUrl = to.ProfileImageUrl
                    .Replace("_normal", "_bigger");
            }

            to.ProfileBackgroundColor = from.ProfileBackgroundColor;
            to.ProfileBannerUrl = from.ProfileBannerURL;
            to.FollowersCount = from.FollowersCount;
            to.StatusesCount = from.StatusesCount;
            to.FriendsCount = from.FriendsCount;
            to.ScreenName = from.ScreenName;
            to.Verified = from.Verified;

            return  to;
        }
    }
}
