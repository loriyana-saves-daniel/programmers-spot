using Moq;
using NUnit.Framework;
using ProgrammersSpot.Business.Data.Contracts;
using ProgrammersSpot.Business.Models.Locations;
using System.Collections.Generic;
using System.Linq;

namespace ProgrammersSpot.Business.Services.Tests.LocationServiceTests
{
    [TestFixture]
    public class GetAllCountries_Should
    {
        [Test]
        public void ReturnAllCountries_WhenThereAreCountries()
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

            var expectedCountries = (IEnumerable<Country>)new List<Country>() { new Country(), new Country() };
            mockedCountryRepository.Setup(repository => repository.All()).Returns(() => expectedCountries.AsQueryable());

            //Act & Assert
            Assert.AreEqual(locationService.GetAllCountries().Count(), 2);
        }

        [Test]
        public void ReturnEmptyCollection_WhenTheAreNoCountries()
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

            var expectedCountries = (IEnumerable<Country>)new List<Country>();
            mockedCountryRepository.Setup(repository => repository.All()).Returns(() => expectedCountries.AsQueryable());

            //Act & Assert
            Assert.IsEmpty(locationService.GetAllCountries());
        }
    }
}
