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
            var items = await this.GetAllSavedbyUserAsync(claimsHelper.GetUserId());
            return items.Select(x => x.StatusId);
        }

        public async Task<IEnumerable<Status>> GetAllSavedbyUserAsync(string userId)
        {
            var savedStatuses = await this.dbContext.Statuses.FindAsync(x => x.SavedByUserId == userId);
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
    }
}
