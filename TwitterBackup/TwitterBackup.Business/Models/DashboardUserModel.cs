namespace Business.Models
{
    public class DashboardUserModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string ScreenName { get; set; }

        public string ProfileImageUrl { get; set; }

        public int FavoriteUsersCount { get; set; }

        public int DownloadsCount { get; set; }

        public int RetweetsCount { get; set; }

        public bool RetweetsCountIsAccurate { get; set; }
    }
}
