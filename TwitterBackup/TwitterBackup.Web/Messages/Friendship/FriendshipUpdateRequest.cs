namespace TwitterBackup.Web.Messages.Friendship
{
    public class FriendshipUpdateRequest
    {
        public string ScreenName { get; set; }

        public bool Notifications { get; set; }
    }
}