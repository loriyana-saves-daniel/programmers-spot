using ProgrammersSpot.Business.Models.Users.Contracts;
using System.Collections.Generic;

namespace ProgrammersSpot.Business.MVP.ViewModels
{
    public class UserProfileViewModel
    {
        public IRegularUser FoundRegularUser { get; set; }

        public IFirmUser FoundFirmUser { get; set; }

        public string ProfileImage { get; set; }
    }
}
