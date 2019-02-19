using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DiplomadoMVC.Startup))]
namespace DiplomadoMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            ConfigureRoles();
        }
    }
}
