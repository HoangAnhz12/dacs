using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(webTimPhong.Startup))]
namespace webTimPhong
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
