﻿using System.Collections.Generic;
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

        public async Task<IEnumerable<Status>> GetUserTimelineAsync(string screenName)
        {
            var user = await Auth.ExecuteOperationWithCredentials(
                this.credentials, () => UserAsync.GetUserFromScreenName(screenName));
            
            var userTimelineParam = new UserTimelineParameters
            {
                MaximumNumberOfTweetsToRetrieve = 100,
                IncludeRTS = true,
                TrimUser = true
            };
            
            var tweets = await user.GetUserTimelineAsync(userTimelineParam);

            return tweets.Select(x => new Status
            {
                Id = x.IdStr,
                Text = x.Text,
                RetweetCount = x.RetweetCount,
                Retweeted = x.Retweeted,
                FavoriteCount = x.FavoriteCount,
                Favorited = x.Favorited,
                CreatedAt = x.CreatedAt,
                //Entities = x.Entities.M
            });
        }
    }
}