using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwitterBackup.DataAccess.Credentials;
using TwitterBackup.DataAccess.Entities;
using TwitterBackup.DataAccess.Entities.Mapping;
using Tweetinvi;
using Tweetinvi.Parameters;
using Tweetinvi.Models;

namespace TwitterBackup.DataAccess.Repositories.Statuses
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

        public virtual async Task<IEnumerable<Status>> GetUserTimelineAsync(StatusListParams statusListParams)
        {
            var userTimelineParam = new UserTimelineParameters
            {
                MaximumNumberOfTweetsToRetrieve = statusListParams.Count ?? 100,
                IncludeRTS = true
            };

            if (!string.IsNullOrEmpty(statusListParams.MaxId))
            {
                userTimelineParam.MaxId = long.Parse(statusListParams.MaxId) - 1;
            }

            var userId = new UserIdentifier(long.Parse(statusListParams.CreatedByUserId));
            
            var tweets = await Auth.ExecuteOperationWithCredentials(
                this.credentials, () => TimelineAsync.GetUserTimeline(userId, userTimelineParam));
            
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
            var userTimelineParam = new UserTimelineParameters
            {
                MaximumNumberOfTweetsToRetrieve = 200,
                IncludeRTS = true,
                TrimUser = true,
                IncludeEntities = false,
                ExcludeReplies = true,                
            };

            var user = new UserIdentifier(long.Parse(userId));

            var tweets = Auth.ExecuteOperationWithCredentials(
                this.credentials, () => Timeline.GetUserTimeline(user, userTimelineParam));

            return tweets.Count(x => x.IsRetweet);
        }
    }
}
