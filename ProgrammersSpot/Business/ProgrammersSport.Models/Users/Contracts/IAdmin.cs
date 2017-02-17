using System.Collections.Generic;

namespace ProgrammersSpot.Business.Models.Users.Contracts
{
    public interface IAdmin
    {
        string Id { get; set; }

        User User { get; set; }

        bool IsDeleted { get; set; }

        ICollection<FirmUser> FirmRegistrationRequests { get; set; }
    }
}
