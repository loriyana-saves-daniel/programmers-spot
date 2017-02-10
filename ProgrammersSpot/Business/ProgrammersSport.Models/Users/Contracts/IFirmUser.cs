using ProgrammersSpot.Business.Models.Reviews;
using System.Collections.Generic;

namespace ProgrammersSpot.Business.Models.Users.Contracts
{
    public interface IFirmUser
    {
        string Address { get; set; }

        int EmployeesCount { get; set; }

        int Rating { get; set; }

        string Website { get; set; }

        bool IsApproved { get; set; }

        ICollection<IReview> FirmReviews { get; set; }
    }
}
