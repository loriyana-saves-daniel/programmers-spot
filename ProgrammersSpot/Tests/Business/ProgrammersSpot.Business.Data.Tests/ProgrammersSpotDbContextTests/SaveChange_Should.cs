using Moq;
using NUnit.Framework;
using ProgrammersSpot.Business.Data.Contracts;
using ProgrammersSpot.Business.Models.Locations;
using ProgrammersSpot.Business.Models.UserRoles;
using ProgrammersSpot.Business.Models.Users;
using ProgrammersSpot.Business.Services;

namespace ProgrammersSpot.Business.Data.Tests.ProgrammersSpotDbContextTests
{
    [TestFixture]
    public class SaveChange_Should
    {
        [Test]
        public void SaveChanges_ShouldWorkAppropriately()
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
            var firmEmail = "telerik.com";
            var mockedCountry = new Mock<Country>();
            var mockedCity = new Mock<City>();

            // Act            
            registrationService.CreateFirm(firmId, firmName, firmEmail, mockedCountry.Object, mockedCity.Object, firmAddress);

            // Assert
            mockedUnitOfWork.Verify(x => x.SaveChanges(), Times.Once);
        }
    }
}
