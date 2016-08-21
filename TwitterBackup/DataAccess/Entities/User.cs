namespace DataAccess.Entities
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
        /*
"profile_link_color": "2FC2EF",
"profile_text_color": "666666",
"profile_background_tile": false,
"profile_use_background_image": true,
"profile_background_image_url": "http://a0.twimg.com/images/themes/theme9/bg.gif",
"default_profile_image": false,
"favourites_count": 1973,
*/
    }
}