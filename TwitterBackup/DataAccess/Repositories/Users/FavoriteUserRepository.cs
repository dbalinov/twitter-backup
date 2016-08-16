using System;
using System.Collections.Generic;
using System.Linq;
using LinqToTwitter;
using System.Web.Configuration;

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

        public IEnumerable<DataAccess.Entities.User> GetAll()
        {
            var ctx = new TwitterContext(this.auth);
            // var favorites = ctx.Favorites;

            Friendship friendship;
            long cursor = -1;
            do
            {
                friendship =
                    //await 
                    (from friend in ctx.Friendship
                        where friend.Type == FriendshipType.FriendsList &&
                              friend.UserID == this.userId &&
                              friend.Cursor == cursor
                        select friend)
                        .SingleOrDefault(); //Async();

                if (friendship != null &&
                    friendship.Users != null &&
                    friendship.CursorMovement != null)
                {
                    cursor = friendship.CursorMovement.Next;

                    foreach (var friend in friendship.Users)
                    {
                        yield return new DataAccess.Entities.User {Name = friend.Name};
                    }
                }

            } while (cursor != 0);

            //var users = ctx.Friendship
            //    .FirstOrDefault(x => x.Type == FriendshipType.FriendsList && x.UserID == this.userId)
            //    .Users;
            //var responseTweet = users
            //    .Select(x => new DataAccess.Entities.User {Name = x.Name});
            //return responseTweet;
        }
    }
}
