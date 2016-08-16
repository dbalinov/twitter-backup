using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TwitterBackup.Web.Startup))]
namespace TwitterBackup.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
