using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ORACLELab.Startup))]
namespace ORACLELab
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
