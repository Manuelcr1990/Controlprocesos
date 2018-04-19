using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Controlprocesos.Startup))]
namespace Controlprocesos {
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
            ConfigureRoles();
        }
    }
}
