using Moq;
using NUnit.Framework;
using ProgrammersSpot.Business.Data.Contracts;
using ProgrammersSpot.Business.Models.Locations;

namespace ProgrammersSpot.Business.Services.Tests.LocationServiceTests
{
    [TestFixture]
    public class GetCountryByName_Should
    {
        [Test]
        public void BeCalled_WhenPassedParametersAreValid()
        {
            //Arrange
            var mockedCountryRepository = new Mock<ICountryRepository>();
            var mockedCityRepository = new Mock<ICityRepository>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var locationService = new LocationService(
                mockedCountryRepository.Object,
                mockedCityRepository.Object,
                mockedUnitOfWork.Object
            );

            var country = new Mock<Country>();
            locationService.GetCountryByName(country.Object.Name);

            //Act & Assert
            mockedCountryRepository.Verify(repository => repository.GetByName(country.Object.Name), Times.Once);
        }

        [Test]
        public void ReturnCountry_WhenCalledWithRightParameters()
        {
            //Arange
            var mockedCountryRepository = new Mock<ICountryRepository>();
            var mockedCityRepository = new Mock<ICityRepository>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var locationService = new LocationService(
                mockedCountryRepository.Object,
                mockedCityRepository.Object,
                mockedUnitOfWork.Object
            );

            var country = new Mock<Country>();
            mockedCountryRepository.Setup(repository => repository.GetByName(country.Object.Name)).Returns(() => country.Object);

            //Act & Assert
            Assert.IsInstanceOf<Country>(locationService.GetCountryByName(country.Object.Name));
        }

        [Test]
        public void ReturnTheRightCountry_WhenInvoked()
        {
            var mockedCountryRepository = new Mock<ICountryRepository>();
            var mockedCityRepository = new Mock<ICityRepository>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var locationService = new LocationService(
                mockedCountryRepository.Object,
                mockedCityRepository.Object,
                mockedUnitOfWork.Object
            );

            var country = new Mock<Country>();
            mockedCountryRepository.Setup(repository => repository.GetByName(country.Object.Name)).Returns(() => country.Object);

            //Act & Assert
            Assert.AreSame(locationService.GetCountryByName(country.Object.Name), country.Object);
        }
    }
}
