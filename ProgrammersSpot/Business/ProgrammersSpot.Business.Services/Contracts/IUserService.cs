using ProgrammersSpot.Business.Models.Projects;
using ProgrammersSpot.Business.Models.Skills;
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

        void AddSkillToRegularUser(string userId, Skill skill);

        void AddProjectToRegularUser(string userId, Project project);

        void UpdateRegularUserAge(string id, int age);

        void UpdateRegularUserJobTitle(string id, string jobTitle);

        void UpdateRegularUserFacebookProfile(string id, string facebook);

        void UpdateRegularUserGitHubProfile(string id, string gitHub);
    }
}
