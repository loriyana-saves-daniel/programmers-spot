using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProgramersSpot.Client.Startup))]
namespace ProgramersSpot.Client
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);     
        }
    }
}
