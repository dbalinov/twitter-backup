using System.Web.Configuration;
using TwitterBackup.DataAccess.Entities;
using MongoDB.Driver;

namespace TwitterBackup.DataAccess
{
    internal class DbContext : IDbContext
    {
        private readonly IMongoDatabase database;

        public DbContext(IMongoClient client)
        {
           this.database = client.GetDatabase(
                WebConfigurationManager.AppSettings["mongodb:DatabaseName"]);
        }

        public IMongoCollection<Status> Statuses
        {
            get { return database.GetCollection<Status>("Statuses"); }
        }

        public IMongoCollection<FavoriteUserRelation> FavriteUserRelations
        {
            get { return database.GetCollection<FavoriteUserRelation>("FavriteUserRelations"); }
        }

        public IMongoCollection<UserRegister> UserRegisters
        {
            get { return database.GetCollection<UserRegister>("UserRegisters"); }
        }
    }
}
