using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(bootstrap.studt.Startup))]
namespace bootstrap.studt
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
