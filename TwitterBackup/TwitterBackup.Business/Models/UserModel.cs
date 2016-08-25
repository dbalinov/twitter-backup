namespace TwitterBackup.Business.Models
{
    public class UserModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsFavorite { get; set; }
        public string ProfileImageUrl { get; set; }
        public string Url { get; internal set; }
        public string ProfileBackgroundColor { get; set; }
        public string ProfileBannerUrl { get; set; }
        public int FollowersCount { get; set; }
        public int StatusesCount { get; set; }
        public int FriendsCount { get; set; }
        public string ScreenName { get; set; }
        public bool Verified { get; set; }
    }
}
