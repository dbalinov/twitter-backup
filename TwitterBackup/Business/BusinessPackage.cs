using Business.Services.Statuses;
using Business.Services.Users;
using SimpleInjector;
using SimpleInjector.Packaging;

namespace Business
{
    public class BusinessPackage : IPackage
    {
        public void RegisterServices(Container container)
        {
            container.Register<IFavoriteUserService, FavoriteUserService>(Lifestyle.Scoped);
            container.Register<IUserService, UserService>(Lifestyle.Scoped);
            container.Register<IStatusService, StatusService>(Lifestyle.Scoped);
        }
    }
}
