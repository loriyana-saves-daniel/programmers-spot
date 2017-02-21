using ProgrammersSpot.Business.Models.Users.Contracts;

namespace ProgrammersSpot.Business.MVP.ViewModels
{
    public class UserProfileViewModel
    {
        public IRegularUser FoundRegularUser { get; set; }

        public IFirmUser FoundFirmUser { get; set; }
    }
}
