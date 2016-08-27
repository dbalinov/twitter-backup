using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwitterBackup.DataAccess.Credentials;
using TwitterBackup.DataAccess.Entities;
using TwitterBackup.Infrastructure.Cacheing;

namespace TwitterBackup.DataAccess.Repositories.Statuses
{
    internal class CachedStatusRepository : StatusRepository
    {
        private readonly ICacheProvider cacheProvider;

        public CachedStatusRepository(ITwitterCredentialsFactory credentialsFactory, ICacheProvider cacheProvider)
            : base(credentialsFactory)
        {
            this.cacheProvider = cacheProvider;
        }

        public override async Task<IEnumerable<Status>> GetUserTimelineAsync(StatusListParams statusListParams)
        {
            if (!statusListParams.Count.HasValue)
            {
                return await base.GetUserTimelineAsync(statusListParams);
            }

            var key = string.Format("user_timeline_{0}", statusListParams.CreatedByUserId);

            var cachedResult = this.cacheProvider.Get<IEnumerable<Status>>(key);
            if (cachedResult != null)
            {
                var statuses = cachedResult
                    .SkipWhile(x => x.StatusId != statusListParams.MaxId)
                    .Skip(1)
                    .Take(statusListParams.Count.Value)
                    .ToList();

                if (statuses.Count == statusListParams.Count.Value)
                {
                    return statuses;
                }
            }

            var count = statusListParams.Count.Value;
            statusListParams.Count = 100;
            var result = await base.GetUserTimelineAsync(statusListParams);

            cacheProvider.Set(key, result, TimeSpan.FromMinutes(5));

            return result.Take(count);
        }
    }
}
