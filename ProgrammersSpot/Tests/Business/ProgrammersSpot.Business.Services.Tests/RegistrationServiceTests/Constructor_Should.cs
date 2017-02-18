using Moq;
using NUnit.Framework;
using ProgrammersSpot.Business.Data.Contracts;
using ProgrammersSpot.Business.Models.UserRoles;
using ProgrammersSpot.Business.Models.Users;
using System;

namespace ProgrammersSpot.Business.Services.Tests.RegistrationServiceTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void CreateNewRegistrationService_WhenParamsAreValid()
        {
            //Arrange
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

            //Act & Assert
            Assert.IsInstanceOf<RegistrationService>(registrationService);
        }

        [Test]
        public void ThrowNullException_WhenRoleRepositoryIsNull()
        {
            //Arrange
            var mockedRoleRepository = (IRepository<Role>)null;
            var mockedUserRepository = new Mock<IRepository<RegularUser>>();
            var mockedFirmRepository = new Mock<IRepository<FirmUser>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() =>
                new RegistrationService(
                    mockedRoleRepository,
                    mockedUserRepository.Object,
                    mockedFirmRepository.Object,
                    mockedUnitOfWork.Object
                )
            );
        }

        [Test]
        public void ThrowNullException_WhenUserRepositoryIsNull()
        {
            //Arrange
            var mockedRoleRepository = new Mock<IRepository<Role>>();
            var mockedUserRepository = (IRepository<RegularUser>)null;
            var mockedFirmRepository = new Mock<IRepository<FirmUser>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() =>
                new RegistrationService(
                    mockedRoleRepository.Object,
                    mockedUserRepository,
                    mockedFirmRepository.Object,
                    mockedUnitOfWork.Object
                )
            );
        }

        [Test]
        public void ThrowNullException_WhenFirmRepositoryIsNull()
        {
            //Arrange
            var mockedRoleRepository = new Mock<IRepository<Role>>();
            var mockedUserRepository = new Mock<IRepository<RegularUser>>();
            var mockedFirmRepository = (IRepository<FirmUser>)null;
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() =>
                new RegistrationService(
                    mockedRoleRepository.Object,
                    mockedUserRepository.Object,
                    mockedFirmRepository,
                    mockedUnitOfWork.Object
                )
            );
        }

        [Test]
        public void ThrowNullException_WhenUnitOfWorkIsNull()
        {
            //Arrange
            var mockedRoleRepository = new Mock<IRepository<Role>>();
            var mockedUserRepository = new Mock<IRepository<RegularUser>>();
            var mockedFirmRepository = new Mock<IRepository<FirmUser>>();
            var mockedUnitOfWork = (IUnitOfWork) null;

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() =>
                new RegistrationService(
                    mockedRoleRepository.Object,
                    mockedUserRepository.Object,
                    mockedFirmRepository.Object,
                    mockedUnitOfWork
                )
            );
        }
    }
}
