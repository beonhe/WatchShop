using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WatchShop.Startup))]
namespace WatchShop
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
