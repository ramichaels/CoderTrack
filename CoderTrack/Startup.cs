using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CoderTrack.Startup))]
namespace CoderTrack
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
