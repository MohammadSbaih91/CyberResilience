using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CyberResilience.Startup))]
namespace CyberResilience
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
