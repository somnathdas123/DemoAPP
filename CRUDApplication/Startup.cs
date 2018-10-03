using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CRUDApplication.Startup))]
namespace CRUDApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
