using Bytes2you.Validation;
using ProgrammersSpot.Business.Data.Contracts;
using ProgrammersSpot.Business.Models.Projects;
using ProgrammersSpot.Business.Models.Skills;
using ProgrammersSpot.Business.Models.Users;
using ProgrammersSpot.Business.Services.Contracts;
using System.Collections.Generic;

namespace ProgrammersSpot.Business.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<RegularUser> usersRepo;
        private readonly IRepository<FirmUser> firmsRepo;
        private readonly IUnitOfWork unitOfWork;

        public UserService(IRepository<RegularUser> usersRepo, IRepository<FirmUser> firmsRepo, 
            IUnitOfWork unitOfWork)
        {
            Guard.WhenArgument(usersRepo, "usersRepo").IsNull().Throw();
            Guard.WhenArgument(firmsRepo, "firmsRepo").IsNull().Throw();
            Guard.WhenArgument(unitOfWork, "unitOfWork").IsNull().Throw();

            this.usersRepo = usersRepo;
            this.firmsRepo = firmsRepo;
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<RegularUser> GetAllRegularUsers()
        {
            return this.usersRepo.All();
        }

        public IEnumerable<FirmUser> GetAllFirmUsers()
        {
            return this.firmsRepo.All();
        }

        public RegularUser GetRegularUserById(string id)
        {
            return this.usersRepo.GetById(id);
        }

        public FirmUser GetFirmUserById(string id)
        {
            return this.firmsRepo.GetById(id);
        }

        public void UpdateRegularUserAge(string id, int age)
        {
            var user = this.usersRepo.GetById(id);
            user.Age = age;
            using (var unitOfWork = this.unitOfWork)
            {
                this.usersRepo.Update(user);
                unitOfWork.SaveChanges();
            }
        }

        public void UpdateRegularUserJobTitle(string id, string jobTitle)
        {
            var user = this.usersRepo.GetById(id);
            user.JobTitle = jobTitle;
            using (var unitOfWork = this.unitOfWork)
            {
                this.usersRepo.Update(user);
                unitOfWork.SaveChanges();
            }
        }

        public void UpdateRegularUserFacebookProfile(string id, string facebook)
        {
            var user = this.usersRepo.GetById(id);
            user.FacebookProfile = facebook;
            using (var unitOfWork = this.unitOfWork)
            {
                this.usersRepo.Update(user);
                unitOfWork.SaveChanges();
            }
        }

        public void UpdateRegularUserGitHubProfile(string id, string gitHub)
        {
            var user = this.usersRepo.GetById(id);
            user.GitHubProfile = gitHub;
            using (var unitOfWork = this.unitOfWork)
            {
                this.usersRepo.Update(user);
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
    }
}
