using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ProgrammersSpot.Business.Models.Locations;
using System.Collections.Generic;

namespace ProgrammersSpot.Business.MVP.ViewModels
{
    public class RegistrationViewModel
    {
        public IdentityResult Result { get; set; }

        public IEnumerable<IdentityRole> UserRoles { get; set; }

        public IEnumerable<Country> Countries { get; set; }

        public IEnumerable<City> Cities { get; set; }
    }
}
