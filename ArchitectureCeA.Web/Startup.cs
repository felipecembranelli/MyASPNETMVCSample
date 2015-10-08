using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ArchitectureCeA.Web.Startup))]
namespace ArchitectureCeA.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
