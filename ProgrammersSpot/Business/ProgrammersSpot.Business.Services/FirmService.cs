using Bytes2you.Validation;
using ProgrammersSpot.Business.Data.Contracts;
using ProgrammersSpot.Business.Models.Users;
using ProgrammersSpot.Business.Services.Contracts;
using System.Collections.Generic;

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

        public IEnumerable<FirmUser> GetAllFirmUsers()
        {
            return this.firmsRepo.All();
        }

        public FirmUser GetFirmUserById(string id)
        {
            return this.firmsRepo.GetById(id);
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
    }
}
