using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Alquileres.Startup))]
namespace Alquileres
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
