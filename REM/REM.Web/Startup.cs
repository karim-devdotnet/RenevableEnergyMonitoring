using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(REM.Web.Startup))]
namespace REM.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
