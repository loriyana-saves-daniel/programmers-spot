using Moq;
using NUnit.Framework;
using ProgrammersSpot.Business.Data.Contracts;
using ProgrammersSpot.Business.Models.UserRoles;
using ProgrammersSpot.Business.Models.Users;
using System.Collections.Generic;
using System.Linq;

namespace ProgrammersSpot.Business.Services.Tests.RegistrationServiceTests
{
    [TestFixture]
    public class GetAllUserRoles_Should
    {
        [Test]
        public void ReturnAllUserRoles_WhenThereAreUserRoles()
        {
            //Arange
            var mockedRoleRepository = new Mock<IRepository<Role>>();
            var mockedUserRepository = new Mock<IRepository<RegularUser>>();
            var mockedFirmRepository = new Mock<IRepository<FirmUser>>();
            var mockedAdminRepository = new Mock<IRepository<Admin>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var registrationService = new RegistrationService(
                mockedRoleRepository.Object,
                mockedUserRepository.Object,

                mockedFirmRepository.Object,
                mockedUnitOfWork.Object
            );

            var expectedRoles = (IEnumerable<Role>) new List<Role>() { new Role(), new Role() };
            mockedRoleRepository.Setup(repository => repository.All()).Returns(() => expectedRoles.AsQueryable());

            //Act & Assert
            Assert.AreEqual(registrationService.GetAllUserRoles().Count(), 2);
        }

        [Test]
        public void ReturnEmptyCollection_WhenTheAreNoRoles()
        {
            //Arange
            var mockedRoleRepository = new Mock<IRepository<Role>>();
            var mockedUserRepository = new Mock<IRepository<RegularUser>>();
            var mockedFirmRepository = new Mock<IRepository<FirmUser>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var registrationService = new RegistrationService(
                mockedRoleRepository.Object,
                mockedUserRepository.Object,
                mockedFirmRepository.Object,
                mockedUnitOfWork.Object
            );

            var expectedRoles = (IEnumerable<Role>)new List<Role>();
            mockedRoleRepository.Setup(repository => repository.All()).Returns(() => expectedRoles.AsQueryable());

            //Act & Assert
            Assert.IsEmpty(registrationService.GetAllUserRoles());
        }
    }
}
