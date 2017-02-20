using Microsoft.AspNet.Identity;
using ProgrammersSpot.Business.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersSpot.Business.MVP.ViewModels
{
    public class ExternalRegistrationViewModel
    {
        public IdentityResult Result { get; set; }

        public User User { get; set; }
    }
}
