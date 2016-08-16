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
        }
    }
}
