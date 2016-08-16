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
        }
    }
}
