using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Entities;
using Infrastructure.Identity.Claims;
using MongoDB.Driver;

namespace DataAccess.Repositories.Statuses
{
    public class StatusStoreRepository : IStatusStoreRepository
    {
        private readonly IDbContext dbContext;
        private readonly ITwitterClaimsHelper claimsHelper;
        
        public StatusStoreRepository(IDbContext dbContext, ITwitterClaimsHelper claimsHelper)
        {
            this.dbContext = dbContext;
            this.claimsHelper = claimsHelper;
        }

        public async Task<IEnumerable<string>> GetSavedStatusIdsAsync()
        {
            var userId = claimsHelper.GetUserId();
            var statuses = await this.dbContext.Statuses.FindAsync(x => x.SavedByUserId == userId);
            return statuses.ToEnumerable().Select(x => x.StatusId);
        }

        public async Task<IEnumerable<Status>> GetAllSavedAsync(StatusListParams statusListParams)
        {
            var userFilter = new ExpressionFilterDefinition<Status>(
                x => x.SavedByUserId == statusListParams.SavedByUserId &&
                     x.CreatedById == statusListParams.CreatedByUserId);
            
            var maxIdFilter = new JsonFilterDefinition<Status>(
                "{ StatusId: { $lt: '"+ statusListParams.MaxId + "' } }");

            var complexFilter = string.IsNullOrEmpty(statusListParams.MaxId)
                ? userFilter
                : userFilter & maxIdFilter;

            var options = new FindOptions<Status>
            {
                Sort = Builders<Status>.Sort.Descending(x => x.StatusId),
                Limit = 5
            };

            var savedStatuses = await this.dbContext.Statuses.FindAsync(complexFilter, options);

            return savedStatuses.ToEnumerable();
        }

        public async Task SaveAsync(Status status)
        {
            status.SavedByUserId = this.claimsHelper.GetUserId();
            await this.dbContext.Statuses.InsertOneAsync(status);
        }

        public async Task UnsaveAsync(string statusId)
        {
            var userId = this.claimsHelper.GetUserId();
            await this.dbContext.Statuses.DeleteOneAsync(
                x => x.StatusId == statusId && x.SavedByUserId == userId);
        }

        public IEnumerable<Tuple<string, int>> GetDownloadStatusCount(IEnumerable<string> userIds)
        {
            var downloadStatusCount = this.dbContext.Statuses
                .Aggregate(new AggregateOptions { AllowDiskUse = true })
                .Group(x => x.SavedByUserId, x => new Tuple<string, int>(x.Key, x.Count()))
                .ToEnumerable();

            return downloadStatusCount;
        }
    }
}
