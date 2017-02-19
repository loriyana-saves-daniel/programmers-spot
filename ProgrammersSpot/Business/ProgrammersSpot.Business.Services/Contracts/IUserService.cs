using ProgrammersSpot.Business.Models.Users;
using System.Collections.Generic;

namespace ProgrammersSpot.Business.Services.Contracts
{
    public interface IUserService
    {
        IEnumerable<RegularUser> GetAllRegularUsers();

        IEnumerable<FirmUser> GetAllFirmUsers();

        FirmUser GetFirmUserById(string id);

        RegularUser GetRegularUserById(string id);
    }
}
