using System.Threading.Tasks;
using Tweetinvi.Models;
using DataAccess.Credentials;
using DataAccess.Entities;

namespace DataAccess.Repositories.Friendships
{
    public class FriendshipRepository : IFriendshipRepository
    {
        private ITwitterCredentials credentials;

        public FriendshipRepository(ITwitterCredentialsFactory credentialsFactory)
        {
            this.credentials = credentialsFactory.Create();
        }

        public async Task<Friendship> GetAsync(string screenName)
        {
            var authenticatedUser = Tweetinvi.User.GetAuthenticatedUser(this.credentials);

            var relationship = await authenticatedUser.GetRelationshipWithAsync(screenName);

            return new Friendship
            {
                ScreenName = screenName,
                WantRetweets = relationship.WantRetweets,
                NotificationsEnabled = relationship.NotificationsEnabled
            };
        }

        public async Task UpdateAsync(Friendship friendship)
        {
            var authenticatedUser = Tweetinvi.User.GetAuthenticatedUser(this.credentials);
            
            await authenticatedUser.UpdateRelationshipAuthorizationsWithAsync(
                friendship.ScreenName, friendship.WantRetweets, friendship.NotificationsEnabled);
        }
    }
}
