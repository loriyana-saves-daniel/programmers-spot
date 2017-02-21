using Moq;
using NUnit.Framework;
using ProgrammersSpot.Business.Data.Contracts;
using ProgrammersSpot.Business.Models.Locations;
using ProgrammersSpot.Business.Models.UserRoles;
using ProgrammersSpot.Business.Models.Users;
using ProgrammersSpot.Business.Models.Users.Contracts;
using System;

namespace ProgrammersSpot.Business.Services.Tests.RegistrationServiceTests
{
    [TestFixture]
    public class CreateFirm_Should
    {
        [Test]
        public void ThrowNullReferenceException_WhenPassedFirmIsInvalid()
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

            Mock<FirmUser> firmToAdd = null;

            //Act & Assert
            Assert.Throws<NullReferenceException>(() => 
                registrationService.CreateFirm(
                    firmToAdd.Object.Id,
                    firmToAdd.Object.FirmName,
                    firmToAdd.Object.Email,
                    firmToAdd.Object.Country,
                    firmToAdd.Object.City,
                    firmToAdd.Object.Address
                    )
                );
        }

        [Test]
        public void InvokeSaveChanges_WhenFirmIsValid()
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

            var firmToAdd = new Mock<IFirmUser>();
            firmToAdd.Setup(firm => firm.Id).Returns("1");
            firmToAdd.Setup(firm => firm.FirmName).Returns("Telerik");
            firmToAdd.Setup(firm => firm.Country).Returns(new Country());
            firmToAdd.Setup(firm => firm.City).Returns(new City());
            firmToAdd.Setup(firm => firm.Address).Returns("Al. Malinov");
            firmToAdd.Setup(firm => firm.Email).Returns("telerik.com");

            //Act
            registrationService.CreateFirm(
                firmToAdd.Object.Id,
                firmToAdd.Object.FirmName,
                firmToAdd.Object.Email,
                firmToAdd.Object.Country,
                firmToAdd.Object.City,
                firmToAdd.Object.Address
                );

            //Assert
            mockedUnitOfWork.Verify(unit => unit.SaveChanges(), Times.Once);
        }
    }
}
