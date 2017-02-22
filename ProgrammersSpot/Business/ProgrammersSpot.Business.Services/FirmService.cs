using Bytes2you.Validation;
using ProgrammersSpot.Business.Data.Contracts;
using ProgrammersSpot.Business.Models.Reviews;
using ProgrammersSpot.Business.Models.Users;
using ProgrammersSpot.Business.Services.Contracts;
using System.Linq;

namespace ProgrammersSpot.Business.Services
{
    public class FirmService : IFirmService
    {
        private readonly IRepository<FirmUser> firmsRepo;
        private readonly IUnitOfWork unitOfWork;

        public FirmService(IRepository<FirmUser> firmsRepo, IUnitOfWork unitOfWork)
        {
            Guard.WhenArgument(firmsRepo, "firmsRepo").IsNull().Throw();
            Guard.WhenArgument(unitOfWork, "unitOfWork").IsNull().Throw();

            this.firmsRepo = firmsRepo;
            this.unitOfWork = unitOfWork;
        }

        public IQueryable<FirmUser> GetAllFirmUsers()
        {
            return this.firmsRepo.All();
        }

        public IQueryable<FirmUser> GetAllApprovedFirmUsers()
        {
            return this.firmsRepo.All().Where(f => f.IsApproved == true);
        }

        public FirmUser GetFirmUserById(string id)
        {
            return this.firmsRepo.GetById(id);
        }

        public IQueryable<FirmUser> GetFirmsWithName(string nameKeyword)
        {
            return this.firmsRepo.All().Where(f => f.FirmName.Contains(nameKeyword));
        }

        public void UpdateFirmUserAddress(string id, string address)
        {
            var firm = this.firmsRepo.GetById(id);
            firm.Address = address;
            using (var unitOfWork = this.unitOfWork)
            {
                this.firmsRepo.Update(firm);
                unitOfWork.SaveChanges();
            }
        }

        public void UpdateFirmUserEmployeesCount(string id, int employeesCount)
        {
            var firm = this.firmsRepo.GetById(id);
            firm.EmployeesCount = employeesCount;
            using (var unitOfWork = this.unitOfWork)
            {
                this.firmsRepo.Update(firm);
                unitOfWork.SaveChanges();
            }
        }

        public void UpdateFirmUserWebsite(string id, string website)
        {
            var firm = this.firmsRepo.GetById(id);
            firm.Website = website;
            using (var unitOfWork = this.unitOfWork)
            {
                this.firmsRepo.Update(firm);
                unitOfWork.SaveChanges();
            }
        }

        public void UpdateFirmUserAvatarUrl(string id, string avatarUrl)
        {
            var user = this.firmsRepo.GetById(id);
            user.AvatarUrl = avatarUrl;
            using (var unitOfWork = this.unitOfWork)
            {
                this.firmsRepo.Update(user);
                unitOfWork.SaveChanges();
            }
        }

        public void MakeFirmReview(string firmId, string review, string authorId)
        {
            var firm = this.GetFirmUserById(firmId);
            firm.FirmReviews.Add(new Review() { AuthorId = authorId, Content = review });

            using (var unitOfWork = this.unitOfWork)
            {
                this.firmsRepo.Update(firm);
                unitOfWork.SaveChanges();
            }
        }

        public void UpdateFirmUser(FirmUser user)
        {
            var userToUpdate = this.firmsRepo.GetById(user.Id);
            if (userToUpdate != null)
            {
                userToUpdate.FirmName = user.FirmName;
                userToUpdate.AvatarUrl = user.AvatarUrl;
                userToUpdate.Email = user.Email;
                userToUpdate.Address = user.Address;
                userToUpdate.EmployeesCount = user.EmployeesCount;
                userToUpdate.Rating = user.Rating;
                userToUpdate.Website = user.Website;
                userToUpdate.IsApproved = user.IsApproved;
                userToUpdate.IsDeleted = user.IsDeleted;
                using (var unitOfWork = this.unitOfWork)
                {
                    this.firmsRepo.Update(userToUpdate);
                    unitOfWork.SaveChanges();
                }
            }
        }
    }
}
