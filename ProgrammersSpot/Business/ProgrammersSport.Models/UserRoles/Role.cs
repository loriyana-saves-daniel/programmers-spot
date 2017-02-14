using Microsoft.AspNet.Identity.EntityFramework;

namespace ProgrammersSpot.Business.Models.UserRoles
{
    public class Role : IdentityRole
    {
        public Role() : base() { }
        public Role(string name) : base(name) { }

        public string Description { get; set; }
    }
}
