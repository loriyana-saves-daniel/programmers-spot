using Bytes2you.Validation;
using ProgrammersSpot.Business.Data.Contracts;
using ProgrammersSpot.Business.Models.Projects;
using ProgrammersSpot.Business.Models.Skills;
using ProgrammersSpot.Business.Models.Users;
using ProgrammersSpot.Business.Services.Contracts;
using System.Linq;

namespace ProgrammersSpot.Business.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<RegularUser> regularUsersRepo;
        private readonly IRepository<FirmUser> firmUsersRepo;
        private readonly IRepository<User> usersRepo;
        private readonly IUnitOfWork unitOfWork;

        public UserService(IRepository<RegularUser> regularUsersRepo, IRepository<User> usersRepo, 
            IRepository<FirmUser> firmUsersRepo, IUnitOfWork unitOfWork)
        {
            Guard.WhenArgument(regularUsersRepo, "regularUsersRepo").IsNull().Throw();
            Guard.WhenArgument(firmUsersRepo, "firmUsersRepo").IsNull().Throw();
            Guard.WhenArgument(usersRepo, "usersRepo").IsNull().Throw();
            Guard.WhenArgument(unitOfWork, "unitOfWork").IsNull().Throw();

            this.usersRepo = usersRepo;
            this.firmUsersRepo = firmUsersRepo;
            this.regularUsersRepo = regularUsersRepo;
            this.unitOfWork = unitOfWork;
        }

        public User GetUserById(string id)
        {
            return this.usersRepo.GetById(id);
        }

        public void UpdateRegularUserAvatarUrl(string id, string avatarUrl)
        {
            var user = this.regularUsersRepo.GetById(id);
            user.AvatarUrl = avatarUrl;
            using (var unitOfWork = this.unitOfWork)
            {
                this.regularUsersRepo.Update(user);
                unitOfWork.SaveChanges();
            }
        }

        public IQueryable<RegularUser> GetAllRegularUsers()
        {
            return this.regularUsersRepo.All();
        }

        public RegularUser GetRegularUserById(string id)
        {
            return this.regularUsersRepo.GetById(id);
        }

        public void UpdateRegularUserAge(string id, int age)
        {
            var user = this.regularUsersRepo.GetById(id);
            user.Age = age;
            using (var unitOfWork = this.unitOfWork)
            {
                this.regularUsersRepo.Update(user);
                unitOfWork.SaveChanges();
            }
        }

        public void UpdateRegularUserJobTitle(string id, string jobTitle)
        {
            var user = this.regularUsersRepo.GetById(id);
            user.JobTitle = jobTitle;
            using (var unitOfWork = this.unitOfWork)
            {
                this.regularUsersRepo.Update(user);
                unitOfWork.SaveChanges();
            }
        }

        public void UpdateRegularUserFacebookProfile(string id, string facebook)
        {
            var user = this.regularUsersRepo.GetById(id);
            user.FacebookProfile = facebook;
            using (var unitOfWork = this.unitOfWork)
            {
                this.regularUsersRepo.Update(user);
                unitOfWork.SaveChanges();
            }
        }

        public void UpdateRegularUserGitHubProfile(string id, string gitHub)
        {
            var user = this.regularUsersRepo.GetById(id);
            user.GitHubProfile = gitHub;
            using (var unitOfWork = this.unitOfWork)
            {
                this.regularUsersRepo.Update(user);
                unitOfWork.SaveChanges();
            }
        }

        public void AddSkillToRegularUser(string userId, Skill skill)
        {
            var user = this.GetRegularUserById(userId);

            using (var unitOfWork = this.unitOfWork)
            {
                user.Skills.Add(skill);
                unitOfWork.SaveChanges();
            }
        }

        public void AddProjectToRegularUser(string userId, Project project)
        {
            var user = this.GetRegularUserById(userId);

            using (var unitOfWork = this.unitOfWork)
            {
                user.Projects.Add(project);
                unitOfWork.SaveChanges();
            }
        }

        public void StarUser(string loggedUserId, string starredUserId)
        {
            var loggedUser = this.GetRegularUserById(loggedUserId);
            var starredUser = this.GetRegularUserById(starredUserId);

            starredUser.StarsCount++;
            loggedUser.StarredUsers.Add(starredUser);

            using (var unitOfWork = this.unitOfWork)
            {
                this.regularUsersRepo.Update(starredUser);
                this.regularUsersRepo.Update(loggedUser);
                unitOfWork.SaveChanges();
            }
        }

        public void UnstarUser(string loggedUserId, string starredUserId)
        {
            var loggedUser = this.GetRegularUserById(loggedUserId);
            var starredUser = this.GetRegularUserById(starredUserId);

            starredUser.StarsCount--;
            loggedUser.StarredUsers.Remove(starredUser);

            using (var unitOfWork = this.unitOfWork)
            {
                this.regularUsersRepo.Update(starredUser);
                this.regularUsersRepo.Update(loggedUser);
                unitOfWork.SaveChanges();
            }
        }

        public void StarFirm(string loggedUserId, string starredFirmId)
        {
            var loggedUser = this.GetRegularUserById(loggedUserId);
            var starredUser = this.firmUsersRepo.GetById(starredFirmId);

            starredUser.Rating++;
            loggedUser.StarredFirms.Add(starredUser);

            using (var unitOfWork = this.unitOfWork)
            {
                this.firmUsersRepo.Update(starredUser);
                this.regularUsersRepo.Update(loggedUser);
                unitOfWork.SaveChanges();
            }
        }

        public void UnstarFirm(string loggedUserId, string starredFirmId)
        {
            var loggedUser = this.GetRegularUserById(loggedUserId);
            var starredUser = this.firmUsersRepo.GetById(starredFirmId);

            starredUser.Rating--;
            loggedUser.StarredFirms.Remove(starredUser);

            using (var unitOfWork = this.unitOfWork)
            {
                this.firmUsersRepo.Update(starredUser);
                this.regularUsersRepo.Update(loggedUser);
                unitOfWork.SaveChanges();
            }
        }
    }
}
