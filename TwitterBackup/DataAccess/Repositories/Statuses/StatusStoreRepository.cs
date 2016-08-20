using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.Entities;
using MongoDB.Driver;

namespace DataAccess.Repositories.Statuses
{
    public class StatusStoreRepository : IStatusStoreRepository
    {
        private readonly IMongoCollection<Status> collection;

        public StatusStoreRepository()
        {
            var connectionString = "mongodb://dbalinov:n0password@ds013216.mlab.com:13216/twitter-backup";
            IMongoClient client = new MongoClient(connectionString);
            IMongoDatabase database = client.GetDatabase("twitter-backup");
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
