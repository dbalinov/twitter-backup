using System;
using System.Collections.Generic;
using System.Linq;
using LinqToTwitter;
using System.Web.Configuration;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Users
{
    public class FavoriteUserRepository : IFavoriteUserRepository
    {
        private readonly MvcAuthorizer auth;
        private readonly string userId;

        public FavoriteUserRepository(string oAuthToken, string oAuthTokenSecret, string userId)
        {
            this.userId = userId;
            this.auth = new MvcAuthorizer
            {
                CredentialStore = new SessionStateCredentialStore
                {
                    ConsumerKey = WebConfigurationManager.AppSettings["twitter:ConsumerKey"],
                    ConsumerSecret = WebConfigurationManager.AppSettings["twitter:ConsumerSecret"],
                    OAuthToken = oAuthToken,
                    OAuthTokenSecret = oAuthTokenSecret,
                    //UserID = claimsHelper.GetUserId()
                }
           };
        }

        public async Task<IEnumerable<DataAccess.Entities.User>> GetAllAsync()
        {
            var ctx = new TwitterContext(this.auth);
            // var favorites = ctx.Favorites;
            var result = new List<DataAccess.Entities.User>();
            Friendship friendship;
            long cursor = -1;
            do
            {
                friendship = await ctx.Friendship
                    .Where(friend => friend.Type == FriendshipType.FriendsList &&
                        friend.UserID == this.userId &&
                        friend.Cursor == cursor)
                    .SingleOrDefaultAsync();

                if (friendship != null &&
                    friendship.Users != null &&
                    friendship.CursorMovement != null)
                {
                    cursor = friendship.CursorMovement.Next;

                    foreach (var friend in friendship.Users)
                    {
                        var user = new DataAccess.Entities.User
                        {
                            Id = friend.UserIDResponse,
                            Name = friend.Name,
                            Description = friend.Description,
                            Notifications = friend.Notifications
                        };
                        result.Add(user);
                    }
                }

            } while (cursor != 0);

            return result;
        }
    }
}
