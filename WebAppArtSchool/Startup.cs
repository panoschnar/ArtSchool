using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebAppArtSchool.Startup))]
namespace WebAppArtSchool
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
