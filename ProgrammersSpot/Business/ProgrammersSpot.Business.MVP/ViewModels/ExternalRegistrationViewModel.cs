using Microsoft.AspNet.Identity;
using ProgrammersSpot.Business.Models.Users;

namespace ProgrammersSpot.Business.MVP.ViewModels
{
    public class ExternalRegistrationViewModel
    {
        public IdentityResult Result { get; set; }

        public User User { get; set; }
    }
}
