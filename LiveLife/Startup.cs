using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LiveLife.Startup))]
namespace LiveLife
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
