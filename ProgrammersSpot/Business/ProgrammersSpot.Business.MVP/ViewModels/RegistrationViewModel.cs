using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;

namespace ProgrammersSpot.Business.MVP.ViewModels
{
    public class RegistrationViewModel
    {
        public IdentityResult Result { get; set; }

        public IEnumerable<IdentityRole> UserRoles { get; set; }
    }
}
