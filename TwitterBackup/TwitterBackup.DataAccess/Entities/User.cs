namespace TwitterBackup.DataAccess.Entities
{
    public class User
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Url { get; set; }

        public string ProfileImageUrl { get; set; }

        public string ProfileBackgroundColor { get; set; }

        public string ProfileBannerUrl { get; set; }

        public string ScreenName { get; set; }

        public int FriendsCount { get; set; }

        public int StatusesCount { get; set; }

        public int FollowersCount { get; set; }

        public bool Verified { get; set; }
    }
}