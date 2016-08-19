using DataAccess.Entities;

namespace Business.Models.Mapping
{
    public class FriendshipMapper
    {
        public FriendshipModel Map(Friendship from, FriendshipModel to)
        {
            to.ScreenName = from.ScreenName;
            to.NotificationsEnabled = from.NotificationsEnabled;
            to.WantRetweets = from.WantRetweets;

            return to;
        }

        public Friendship Map(FriendshipModel from, Friendship to)
        {
            to.ScreenName = from.ScreenName;
            to.NotificationsEnabled = from.NotificationsEnabled;
            to.WantRetweets = from.WantRetweets;

            return to;
        }
    }
}
