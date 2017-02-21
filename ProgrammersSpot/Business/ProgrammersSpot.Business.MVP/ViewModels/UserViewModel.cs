using ProgrammersSpot.Business.Models.Users.Contracts;

namespace ProgrammersSpot.Business.MVP.ViewModels
{
    public class UserViewModel
    {
        public IRegularUser FoundRegularUser { get; set; }

        public string ProfileImage { get; set; }
    }
}
