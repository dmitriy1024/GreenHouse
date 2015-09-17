using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GreenHouse.WebUI.Startup))]
namespace GreenHouse.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
