using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(INVEWEB.Startup))]
namespace INVEWEB
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
