using Moq;
using NUnit.Framework;
using ProgrammersSpot.Business.Data.Contracts;
using ProgrammersSpot.Business.Models.Locations;

namespace ProgrammersSpot.Business.Services.Tests.LocationServiceTests
{
    [TestFixture]
    public class GetCityByName_Should
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

            var city = new Mock<City>();
            locationService.GetCityByName(city.Object.Name);

            //Act & Assert
            mockedCityRepository.Verify(repository => repository.GetByName(city.Object.Name), Times.Once);
        }

        [Test]
        public void ReturnCity_WhenCalledWithRightParameters()
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

            var city = new Mock<City>();
            mockedCityRepository.Setup(repository => repository.GetByName(city.Object.Name)).Returns(() => city.Object);

            //Act & Assert
            Assert.IsInstanceOf<City>(locationService.GetCityByName(city.Object.Name));
        }

        [Test]
        public void ReturnTheRightCity_WhenInvoked()
        {
            var mockedCountryRepository = new Mock<ICountryRepository>();
            var mockedCityRepository = new Mock<ICityRepository>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var locationService = new LocationService(
                mockedCountryRepository.Object,
                mockedCityRepository.Object,
                mockedUnitOfWork.Object
            );

            var city = new Mock<City>();
            mockedCityRepository.Setup(repository => repository.GetByName(city.Object.Name)).Returns(() => city.Object);

            //Act & Assert
            Assert.AreSame(locationService.GetCityByName(city.Object.Name), city.Object);
        }
    }
}
