using Moq;
using NUnit.Framework;
using ProgrammersSpot.Business.Data.Contracts;
using ProgrammersSpot.Business.Models.Locations;
using System.Collections.Generic;
using System.Linq;

namespace ProgrammersSpot.Business.Services.Tests.LocationServiceTests
{
    [TestFixture]
    public class GetAllCities_Should
    {
        [Test]
        public void ReturnAllCities_WhenThereAreCities()
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

            var expectedCities = (IEnumerable<City>)new List<City>() { new City(), new City() };
            mockedCityRepository.Setup(repository => repository.All()).Returns(() => expectedCities.AsQueryable());

            //Act & Assert
            Assert.AreEqual(locationService.GetAllCities().Count(), 2);
        }

        [Test]
        public void ReturnEmptyCollection_WhenTheAreNoCities()
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

            var expectedCities = (IEnumerable<City>)new List<City>();
            mockedCityRepository.Setup(repository => repository.All()).Returns(() => expectedCities.AsQueryable());

            //Act & Assert
            Assert.IsEmpty(locationService.GetAllCities());
        }
    }
}
