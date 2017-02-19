using Bytes2you.Validation;
using ProgrammersSpot.Business.Data.Contracts;
using ProgrammersSpot.Business.Models.Users;
using ProgrammersSpot.Business.Models.Users.Contracts;
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
    }
}
