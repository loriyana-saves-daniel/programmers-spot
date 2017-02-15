using NUnit.Framework;
using ProgrammersSpot.Business.Data.Contracts;
using ProgrammersSpot.Business.Models.Projects;
using Moq;
using ProgrammersSpot.Business.Services;
using ProgrammersSpot.Business.Models.UserRoles;
using ProgrammersSpot.Business.Models.Users;
using ProgrammersSpot.Business.Models.Users.Contracts;
using ProgrammersSport.Business.Models.Locations.Contracts;
using ProgrammersSport.Business.Models.Locations;

namespace ProgrammersSpot.Business.Data.Tests.ProgrammersSpotDbContextTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void Return_InstanceOfIProgrammersSpotDbContext()
        {
            // Arange
            var dbContext = new ProgrammersSpotDbContext();

            // Act & Assert
            Assert.IsInstanceOf<IProgrammersSpotDbContext>(dbContext);
        }

        [Test]
        public void SaveChanges_ShouldWorkCorrectly()
        {
            // Arrange
            var rolesMockedRepository = new Mock<IRepository<Role>>();
            var usersMockedRepository = new Mock<IRepository<RegularUser>>();
            var firmsMockedRepository = new Mock<IRepository<FirmUser>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var registrationService = new RegistrationService(rolesMockedRepository.Object, usersMockedRepository.Object, firmsMockedRepository.Object, mockedUnitOfWork.Object);
            var firmId = "3238726382683t33t276";
            var firmName = "Telerik";
            var firmAddress = "Sofia, Al.Malinov";
            var mockedCountry = new Mock<Country>();
            var mockedCity = new Mock<City>();

            // Act            
            registrationService.CreateFirm(firmId, firmName, mockedCountry.Object, mockedCity.Object, firmAddress);

            // Assert
            mockedUnitOfWork.Verify(x => x.SaveChanges(), Times.Once);
        }
    }
}
