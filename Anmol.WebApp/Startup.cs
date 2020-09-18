using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_Anmol.WebApp.Startup))]
namespace _Anmol.WebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
