using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Homework01.Startup))]
namespace Homework01
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
