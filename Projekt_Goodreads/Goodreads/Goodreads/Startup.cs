using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Goodreads.Startup))]
namespace Goodreads
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
