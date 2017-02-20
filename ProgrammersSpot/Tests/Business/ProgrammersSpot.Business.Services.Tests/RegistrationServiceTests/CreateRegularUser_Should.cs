using Moq;
using NUnit.Framework;
using ProgrammersSpot.Business.Data.Contracts;
using ProgrammersSpot.Business.Models.UserRoles;
using ProgrammersSpot.Business.Models.Users;
using ProgrammersSpot.Business.Models.Users.Contracts;
using System;

namespace ProgrammersSpot.Business.Services.Tests.RegistrationServiceTests
{
    [TestFixture]
    public class CreateRegularUser_Should
    {
        [Test]
        public void ThrowNullReferenceException_WhenPassedUserIsInvalid()
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

            Mock<IRegularUser> userToAdd = null;

            //Act & Assert
            Assert.Throws<NullReferenceException>(() =>
                registrationService.CreateRegularUser(
                    userToAdd.Object.Id,
                    userToAdd.Object.FirstName,
                    userToAdd.Object.LastName,
                    userToAdd.Object.Email
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

            var userToAdd = new Mock<IRegularUser>();
            userToAdd.Setup(firm => firm.Id).Returns("1");
            userToAdd.Setup(firm => firm.FirstName).Returns("Pesho");
            userToAdd.Setup(firm => firm.LastName).Returns("Peshev");
            userToAdd.Setup(firm => firm.Email).Returns("pesho@abv.bg");

            //Act
            registrationService.CreateRegularUser(
                userToAdd.Object.Id,
                userToAdd.Object.FirstName,
                userToAdd.Object.LastName,
                userToAdd.Object.Email
                );

            //Assert
            mockedUnitOfWork.Verify(unit => unit.SaveChanges(), Times.Once);
        }
    }
}
