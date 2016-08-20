using DataAccess.Credentials;
using DataAccess.Repositories.Friendships;
using DataAccess.Repositories.Statuses;
using DataAccess.Repositories.Users;
using MongoDB.Driver;
using SimpleInjector;
using SimpleInjector.Packaging;
using System.Web.Configuration;

namespace DataAccess
{
    public class DataAccessPackage : IPackage
    {
        public void RegisterServices(Container container)
        {
            var mongoConnectionString = WebConfigurationManager.AppSettings["mongodb:ConnectionString"];
            container.Register<IMongoClient>(() => new MongoClient(mongoConnectionString), Lifestyle.Singleton);

            container.Register<IFriendRepository, FriendRepository>(Lifestyle.Scoped);
            container.Register<IFriendshipRepository, FriendshipRepository>(Lifestyle.Scoped);
            container.Register<IStatusRepository, StatusRepository>(Lifestyle.Scoped);
            container.Register<IStatusStoreRepository, StatusStoreRepository>(Lifestyle.Scoped);
            
            container.Register<ITwitterCredentialsFactory, TwitterCredentialsFactory>(Lifestyle.Scoped);
        }
    }
}
