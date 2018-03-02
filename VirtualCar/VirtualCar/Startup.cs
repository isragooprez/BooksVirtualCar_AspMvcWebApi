using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VirtualCar.Startup))]
namespace VirtualCar
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
