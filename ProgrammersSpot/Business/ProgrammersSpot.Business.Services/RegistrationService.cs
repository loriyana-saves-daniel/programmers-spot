using Bytes2you.Validation;
using ProgrammersSpot.Business.Data.Contracts;
using ProgrammersSpot.Business.Models.Locations;
using ProgrammersSpot.Business.Models.UserRoles;
using ProgrammersSpot.Business.Models.Users;
using ProgrammersSpot.Business.Services.Contracts;
using System.Linq;

namespace ProgrammersSpot.Business.Services
{
    public class RegistrationService : IRegistrationService
    {
        private readonly IRepository<Role> userRolesRepo;
        private readonly IRepository<RegularUser> usersRepo;
        private readonly IRepository<FirmUser> firmsRepo;
        private readonly IUnitOfWork unitOfWork;

        public RegistrationService(IRepository<Role> userRolesRepo, IRepository<RegularUser> usersRepo,
            IRepository<FirmUser> firmsRepo, IUnitOfWork unitOfWork)
        {
            Guard.WhenArgument(userRolesRepo, "userRolesRepo").IsNull().Throw();
            Guard.WhenArgument(usersRepo, "usersRepo").IsNull().Throw();
            Guard.WhenArgument(firmsRepo, "firmsRepo").IsNull().Throw();
            Guard.WhenArgument(unitOfWork, "unitOfWork").IsNull().Throw();

            this.userRolesRepo = userRolesRepo;
            this.usersRepo = usersRepo;
            this.firmsRepo = firmsRepo;
            this.unitOfWork = unitOfWork;
        }

        public IQueryable<Role> GetAllUserRoles()
        {
            return this.userRolesRepo.All();        
        }

        public void CreateFirm(string firmId, string firmName, string email, Country country, City city, string address)
        {
            Guard.WhenArgument(firmId, "firmId").IsNullOrEmpty().Throw();
            Guard.WhenArgument(firmName, "firmName").IsNullOrEmpty().Throw();
            Guard.WhenArgument(email, "email").IsNullOrEmpty().Throw();
            Guard.WhenArgument(country, "country").IsNull().Throw();
            Guard.WhenArgument(city, "city").IsNull().Throw();
            Guard.WhenArgument(address, "address").IsNullOrEmpty().Throw();

            using (var uow = this.unitOfWork)
            {
                this.firmsRepo.Add(new FirmUser()
                {
                    Id = firmId,
                    Country = country,
                    FirmName = firmName,
                    Email = email,
                    City = city,
                    Address = address,
                    AvatarUrl = "https://www.programmersspot.com/Content/Images/firm.png"
                });

                uow.SaveChanges();
            }
        }

        public void CreateRegularUser(string userId, string firstName, string lastName, string email)
        {
            Guard.WhenArgument(userId, "userId").IsNullOrEmpty().Throw();
            Guard.WhenArgument(firstName, "firstName").IsNullOrEmpty().Throw();
            Guard.WhenArgument(lastName, "lastName").IsNullOrEmpty().Throw();
            Guard.WhenArgument(email, "email").IsNullOrEmpty().Throw();

            using (var uow = this.unitOfWork)
            {
                this.usersRepo.Add(new RegularUser()
                {
                    Id = userId,
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    AvatarUrl = "https://www.programmersspot.com/Content/Images/profile.png"
                });

                uow.SaveChanges();
            }
        }
    }
}
