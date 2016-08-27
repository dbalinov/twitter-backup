using System.Web.Configuration;
using MongoDB.Driver;

namespace TwitterBackup.DataAccess.Tests
{
    internal class TestUtils
    {
        public static IDbContext GetDbContext()
        {
            var mongoConnectionString = WebConfigurationManager.AppSettings["mongodb:ConnectionString"];
            var mongoClient = new MongoClient(mongoConnectionString);
            var dbContext = new DbContext(mongoClient);
            return dbContext;
        }
    }
}
