using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProgrammersSpot.WebClient.Startup))]
namespace ProgrammersSpot.WebClient
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);     
        }
    }
}
