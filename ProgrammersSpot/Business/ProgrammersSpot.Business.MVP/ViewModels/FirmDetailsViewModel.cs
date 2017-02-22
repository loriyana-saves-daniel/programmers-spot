using ProgrammersSpot.Business.Models.Users;

namespace ProgrammersSpot.Business.MVP.ViewModels
{
    public class FirmDetailsViewModel
    {
        public FirmUser Firm { get; set; }

        public RegularUser LoggedInUser { get; set; }
    }
}
