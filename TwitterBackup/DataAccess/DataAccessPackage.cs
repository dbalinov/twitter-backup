using DataAccess.Credentials;
using DataAccess.Repositories.Friendships;
using DataAccess.Repositories.Statuses;
using DataAccess.Repositories.Users;
using SimpleInjector;
using SimpleInjector.Packaging;

namespace DataAccess
{
    public class DataAccessPackage : IPackage
    {
        public void RegisterServices(Container container)
        {
            container.Register<IFavoriteUserRepository, FavoriteUserRepository>(Lifestyle.Scoped);
            container.Register<IFriendshipRepository, FriendshipRepository>(Lifestyle.Scoped);
            container.Register<IStatusRepository, StatusRepository>(Lifestyle.Scoped);

            container.Register<ITwitterCredentialsFactory, TwitterCredentialsFactory>(Lifestyle.Scoped);
        }
    }
}
