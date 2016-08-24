using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Credentials;
using DataAccess.Entities;
using DataAccess.Entities.Mapping;
using Tweetinvi;
using Tweetinvi.Parameters;
using Tweetinvi.Models;

namespace DataAccess.Repositories.Statuses
{
    internal class StatusRepository : IStatusRepository
    {
        private readonly ITwitterCredentials credentials;

        public StatusRepository(ITwitterCredentialsFactory credentialsFactory)
        {
            this.credentials = credentialsFactory.Create();
        }

        public async Task<Status> GetAsync(string statusId)
        {
            var tweet = await Auth.ExecuteOperationWithCredentials(
                this.credentials, () => TweetAsync.GetTweet(long.Parse(statusId)));
            var mapper = new StatusMapper();
            return mapper.Map(tweet, new Status());
        }

        public async Task<IEnumerable<Status>> GetUserTimelineAsync(StatusListParams statusListParams)
        {
            var user = await Auth.ExecuteOperationWithCredentials(
                this.credentials, () => UserAsync.GetUserFromId(long.Parse(statusListParams.CreatedByUserId)));
            
            var userTimelineParam = new UserTimelineParameters
            {
                MaximumNumberOfTweetsToRetrieve = statusListParams.Count ?? 100,
                IncludeRTS = true,
                TrimUser = true
            };

            if (!string.IsNullOrEmpty(statusListParams.MaxId))
            {
                userTimelineParam.MaxId = long.Parse(statusListParams.MaxId) - 1;
            }

            var tweets = await Auth.ExecuteOperationWithCredentials(
                this.credentials, () => user.GetUserTimelineAsync(userTimelineParam));

            tweets = tweets ?? Enumerable.Empty<ITweet>();

            var mapper = new StatusMapper();
            return tweets.Select(x => mapper.Map(x, new Status()));
        }
        
        public async Task RetweetAsync(string statusId)
        {
            var tweetId = long.Parse(statusId);
            var tweet = await Auth.ExecuteOperationWithCredentials(
                this.credentials, () => TweetAsync.PublishRetweet(tweetId));
        }

        public int GetRetweetsCountForUser(string userId)
        {
            var user = Auth.ExecuteOperationWithCredentials(
                this.credentials, () => Tweetinvi.User.GetUserFromId(long.Parse(userId)));

            var userTimelineParam = new UserTimelineParameters
            {
                MaximumNumberOfTweetsToRetrieve = 200,
                IncludeRTS = true,
                TrimUser = true,
                IncludeEntities = false,
                ExcludeReplies = true,                
            };

            var tweets = Auth.ExecuteOperationWithCredentials(
                this.credentials, () => user.GetUserTimeline(userTimelineParam));

            return tweets.Count(x => x.IsRetweet);
        }
    }
}
