using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(User.UI.Startup))]
namespace User.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
