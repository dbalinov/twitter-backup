using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Entities;
using Tweetinvi;
using Tweetinvi.Parameters;

namespace DataAccess.Repositories.Statuses
{
    public class StatusRepository : IStatusRepository
    {
        public async Task<IEnumerable<Status>> GetUserTimelineAnsync(string screenName)
        {
            var user = Tweetinvi.User.GetUserFromScreenName(screenName);

            var userTimelineParam = new UserTimelineParameters
            {
                MaximumNumberOfTweetsToRetrieve = 100,
                IncludeRTS = true
            };
            
            var tweets = await TimelineAsync.GetUserTimeline(user, userTimelineParam);

            return tweets.Select(x => new Status
            {
                Text = x.Text,
                RetweetCount = x.RetweetCount
            });
        }
    }
}
