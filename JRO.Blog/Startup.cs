using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JRO.Blog.Startup))]
namespace JRO.Blog
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
