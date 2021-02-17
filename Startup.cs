using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Iris.Startup))]
namespace Iris
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
