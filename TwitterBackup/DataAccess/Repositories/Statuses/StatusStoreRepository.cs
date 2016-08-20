using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Entities;
using MongoDB.Driver;

namespace DataAccess.Repositories.Statuses
{
    public class StatusStoreRepository : IStatusStoreRepository
    {
        
        public Task<IEnumerable<Status>> GetAllAsync(long userId)
        {
            var connectionString = "mongodb://dbalinov:n0password@ds013216.mlab.com:13216/twitter-backup";
            IMongoClient client = new MongoClient(connectionString);
            IMongoDatabase database = client.GetDatabase("twitter-backup");
            var statuses = database.GetCollection<Entities.Status>("Statuses");
            throw new NotImplementedException();
        }

        public Task AddAsync(Status status)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(long statusId)
        {
            throw new NotImplementedException();
        }
    }
}
