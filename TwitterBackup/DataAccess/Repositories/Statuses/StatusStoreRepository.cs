using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.Entities;
using MongoDB.Driver;
using System.Web.Configuration;

namespace DataAccess.Repositories.Statuses
{
    public class StatusStoreRepository : IStatusStoreRepository
    {
        private readonly IMongoCollection<Status> collection;

        public StatusStoreRepository(IMongoClient client)
        {
            IMongoDatabase database = client.GetDatabase(
                WebConfigurationManager.AppSettings["mongodb:DatabaseName"]);

            this.collection = database.GetCollection<Status>("Statuses");
        }

        public async Task<IEnumerable<Status>> GetAllAsync(string userId)
        {
            var savedStatuses = await collection.FindAsync(x => x.CreatedById == userId);
            return savedStatuses.ToEnumerable();
        }

        public async Task SaveAsync(Status status)
        {
            await collection.InsertOneAsync(status);
        }

        public async Task UnsaveAsync(string statusId)
        {
            await collection.DeleteOneAsync(x => x.Id == statusId);
        }
    }
}
