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
            container.Register<IFriendService, FriendService>(Lifestyle.Scoped);
            container.Register<IFriendshipService, FriendshipService>(Lifestyle.Scoped);
            container.Register<IStatusService, StatusService>(Lifestyle.Scoped);
        }
    }
}
