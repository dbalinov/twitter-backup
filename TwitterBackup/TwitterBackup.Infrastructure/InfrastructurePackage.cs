using TwitterBackup.Infrastructure.Identity.Claims;
using SimpleInjector;
using SimpleInjector.Packaging;
using TwitterBackup.Infrastructure.Cacheing;

namespace TwitterBackup.Infrastructure
{
    public class InfrastructurePackage : IPackage
    {
        public void RegisterServices(Container container)
        {
            container.Register<ICacheProvider, WebCacheProvider>(Lifestyle.Scoped);
            container.Register<ITwitterClaimsHelper, TwitterClaimsHelper>(Lifestyle.Scoped);
        }
    }
}
