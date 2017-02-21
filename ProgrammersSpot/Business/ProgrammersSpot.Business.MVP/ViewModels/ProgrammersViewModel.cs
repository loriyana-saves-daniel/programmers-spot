using ProgrammersSpot.Business.Models.Users;
using System.Linq;

namespace ProgrammersSpot.Business.MVP.ViewModels
{
    public class ProgrammersViewModel
    {
        public IQueryable<RegularUser> Programmers { get; set; }
    }
}
