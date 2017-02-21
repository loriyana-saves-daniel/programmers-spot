using ProgrammersSpot.Business.Models.Users;
using System.Linq;

namespace ProgrammersSpot.Business.MVP.ViewModels
{
    public class FirmsViewModel
    {
        public IQueryable<FirmUser> Firms { get; set; }
    }
}
