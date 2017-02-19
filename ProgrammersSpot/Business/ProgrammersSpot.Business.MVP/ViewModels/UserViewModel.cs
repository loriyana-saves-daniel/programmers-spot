using ProgrammersSpot.Business.Models.Users.Contracts;
using System.Collections.Generic;

namespace ProgrammersSpot.Business.MVP.ViewModels
{
    public class UserViewModel
    {
        public IRegularUser FoundRegularUser { get; set; }

        //public IEnumerable<IRegularUser> RegularUsers { get; set; }

        //public IEnumerable<IFirmUser> FirmUsers { get; set; }
    }
}
