using ProgrammersSpot.Business.Models.Users.Contracts;
using System.Collections.Generic;

namespace ProgrammersSport.Business.Models.Users.Contracts
{
    public interface IAdmin
    {
        ICollection<IFirmUser> FirmRegistrationRequests { get; set; }
    }
}
