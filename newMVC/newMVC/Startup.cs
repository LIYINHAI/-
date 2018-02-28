using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(newMVC.Startup))]
namespace newMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
