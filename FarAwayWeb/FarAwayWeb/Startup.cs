using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FarAwayWeb.Startup))]
namespace FarAwayWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
