using System.Web.Configuration;
using MongoDB.Driver;
using Tweetinvi.Models;

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

        public static ITwitterCredentials GetCredentials()
        {
            return new TwitterCredentials(
                WebConfigurationManager.AppSettings["twitter:ConsumerKey"],
                WebConfigurationManager.AppSettings["twitter:ConsumerSecret"],
                "3656340495-Bu8Wak5cCQYXBFKdklhVbvH3AvJXrGRfn3m2YPf",
                "ZfNMcX6JW4lAnaVj6pJ38FZYxM00vcCqHUwCaUurW1hoq");
        }
    }
}
