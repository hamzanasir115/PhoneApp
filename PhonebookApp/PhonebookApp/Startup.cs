using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PhonebookApp.Startup))]
namespace PhonebookApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
