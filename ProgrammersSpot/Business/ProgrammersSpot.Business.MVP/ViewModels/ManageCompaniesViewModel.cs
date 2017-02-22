using ProgrammersSpot.Business.Models.Users;
using System.Linq;

namespace ProgrammersSpot.Business.MVP.ViewModels
{
    public class ManageCompaniesViewModel
    {
        public IQueryable<FirmUser> Companies { get; set; }
    }
}
