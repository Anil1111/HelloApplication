using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HelloApplication.Startup))]
namespace HelloApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
