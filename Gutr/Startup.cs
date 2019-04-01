using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Gutr.Startup))]
namespace Gutr
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
