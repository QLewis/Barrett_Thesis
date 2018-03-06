using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Register_Web_App.Startup))]
namespace Register_Web_App
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
