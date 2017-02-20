using ProgrammersSpot.Business.Models.Locations;
using ProgrammersSpot.Business.Models.Reviews;
using System.Collections.Generic;

namespace ProgrammersSpot.Business.Models.Users.Contracts
{
    public interface IFirmUser
    {
        string Id { get; set; }

        string FirmName { get; set; }

        string Email { get; set; }

        string AvatarUrl { get; set; }

        Country Country { get; set; }

        City City { get; set; }

        string Address { get; set; }

        int EmployeesCount { get; set; }

        int Rating { get; set; }

        string Website { get; set; }

        bool IsApproved { get; set; }

        bool IsDeleted { get; set; }

        ICollection<Review> FirmReviews { get; set; }
    }
}
