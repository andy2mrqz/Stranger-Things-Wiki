using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StrangerThings.Startup))]
namespace StrangerThings
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
