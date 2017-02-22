using ProgrammersSpot.Business.Models.Users;

namespace ProgrammersSpot.Business.MVP.ViewModels
{
    public class ProgrammerDetailsViewModel
    {
        public RegularUser Programmer { get; set; }

        public RegularUser LoggedInUser { get; set; }
    }
}
