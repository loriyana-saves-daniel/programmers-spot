using ProgrammersSpot.Business.Models.Locations;
using ProgrammersSpot.Business.Models.UserRoles;
using System.Collections.Generic;

namespace ProgrammersSpot.Business.Services.Contracts
{
    public interface IRegistrationService
    {
        IEnumerable<Role> GetAllUserRoles();

        void CreateRegularUser(string userId, string firstName, string lastName, string email);

        void CreateFirm(string firmId, string firmName, string email, Country country, City city, string address);
    }
}
