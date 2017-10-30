using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Anish.Startup))]
namespace Anish
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
