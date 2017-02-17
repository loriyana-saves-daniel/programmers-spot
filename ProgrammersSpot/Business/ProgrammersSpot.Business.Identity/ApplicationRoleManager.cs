using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using ProgrammersSpot.Business.Data;
using ProgrammersSpot.Business.Models.UserRoles;
using System.Linq;

namespace ProgrammersSpot.Business.Identity
{
    public class ApplicationRoleManager : RoleManager<Role>
    {
        public ApplicationRoleManager(IRoleStore<Role, string> store)
            : base(store)
        {
        }

        public static ApplicationRoleManager Create(IdentityFactoryOptions<ApplicationRoleManager> options, Microsoft.Owin.IOwinContext context)
        {
            var roleManager = new ApplicationRoleManager(new RoleStore<Role>(context.Get<ProgrammersSpotDbContext>()));

            string userRole = "User";
            string adminRole = "Admin";
            string firmRole = "Firm";

            if (context != null && roleManager.Roles.Count() == 0)
            {
                roleManager.Create(new Role(userRole));
                roleManager.Create(new Role(adminRole));
                roleManager.Create(new Role(firmRole));
            }

            return roleManager;
        }
    }
}
