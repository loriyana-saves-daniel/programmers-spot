using ProgrammersSpot.Business.Models.Users;
using System.Collections.Generic;

namespace ProgrammersSpot.Business.Services.Contracts
{
    public interface IFirmService
    {
        IEnumerable<FirmUser> GetAllFirmUsers();

        FirmUser GetFirmUserById(string id);

        void UpdateFirmUserAddress(string id, string address);

        void UpdateFirmUserEmployeesCount(string id, int employeesCount);

        void UpdateFirmUserWebsite(string id, string website);
    }
}
