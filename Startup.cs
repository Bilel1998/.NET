using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(bilel_net.Startup))]
namespace bilel_net
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
