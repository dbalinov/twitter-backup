using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Configuration;
using DataAccess.Entities;
using Infrastructure.Identity.Claims;
using MongoDB.Driver;

namespace DataAccess.Repositories.Statuses
{
    public class StatusStoreRepository : IStatusStoreRepository
    {
        private readonly ITwitterClaimsHelper claimsHelper;
        private readonly IMongoCollection<Status> collection;

        public StatusStoreRepository(IMongoClient client, ITwitterClaimsHelper claimsHelper)
        {
            IMongoDatabase database = client.GetDatabase(
                WebConfigurationManager.AppSettings["mongodb:DatabaseName"]);
            this.claimsHelper = claimsHelper;
            this.collection = database.GetCollection<Status>("Statuses");
        }

        public async Task<IEnumerable<string>> GetSavedStatusIdsAsync()
        {
            var items = await this.GetAllSavedbyUserAsync(claimsHelper.GetUserId());
            return items.Select(x => x.StatusId);
        }

        public async Task<IEnumerable<Status>> GetAllSavedbyUserAsync(string userId)
        {
            var savedStatuses = await collection.FindAsync(x => x.SavedByUserId == userId);
            return savedStatuses.ToEnumerable();
        }

        public async Task SaveAsync(Status status)
        {
            status.SavedByUserId = this.claimsHelper.GetUserId();
            await collection.InsertOneAsync(status);
        }

        public async Task UnsaveAsync(string statusId)
        {
            var userId = this.claimsHelper.GetUserId();
            await collection.DeleteOneAsync(
                x => x.StatusId == statusId && x.SavedByUserId == userId);
        }
    }
}
