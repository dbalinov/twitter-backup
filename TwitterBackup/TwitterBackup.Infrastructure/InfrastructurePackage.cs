using TwitterBackup.Infrastructure.Identity.Claims;
using SimpleInjector;
using SimpleInjector.Packaging;

namespace TwitterBackup.Infrastructure
{
    public class InfrastructurePackage : IPackage
    {
        public void RegisterServices(Container container)
        {
            container.Register<ITwitterClaimsHelper, TwitterClaimsHelper>(Lifestyle.Scoped);
        }
    }
}
