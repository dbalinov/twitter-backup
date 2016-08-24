using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Entities;
using Tweetinvi;
using Tweetinvi.Parameters;
using Tweetinvi.Models;
using DataAccess.Credentials;

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

            return Map(tweet);
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

            return tweets.Select(Map);
        }

        private Status Map(ITweet x)
        {
            var media = x.Entities.Medias.FirstOrDefault();
           
            var status = new Status
            {
                StatusId = x.IdStr,
                Text = x.FullText,
                Retweeted = x.Retweeted,
                CreatedAt = x.CreatedAt,
                CreatedById = x.CreatedBy.IdStr,
                MediaType = media != null ? media.MediaType: null,
                MediaUrl = media != null ? media.MediaURL : null
            };

            return status;
        }

        public async Task RetweetAsync(string statusId)
        {
            var tweetId = long.Parse(statusId);
            var tweet = await Auth.ExecuteOperationWithCredentials(
                this.credentials, () => TweetAsync.PublishRetweet(tweetId));
        }
    }
}
