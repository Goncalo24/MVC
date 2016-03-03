using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(trabalho_pratrico_MVC.Startup))]
namespace trabalho_pratrico_MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
