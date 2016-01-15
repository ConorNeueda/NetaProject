using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NetaWeb.Startup))]
namespace NetaWeb
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
