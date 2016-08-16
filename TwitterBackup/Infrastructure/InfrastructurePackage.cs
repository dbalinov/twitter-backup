using Infrastructure.Identity.Claims;
using SimpleInjector;
using SimpleInjector.Packaging;

namespace Infrastructure
{
    public class InfrastructurePackage : IPackage
    {
        public void RegisterServices(Container container)
        {
            container.Register<ITwitterClaimsHelper, TwitterClaimsHelper>(Lifestyle.Scoped);
        }
    }
}
