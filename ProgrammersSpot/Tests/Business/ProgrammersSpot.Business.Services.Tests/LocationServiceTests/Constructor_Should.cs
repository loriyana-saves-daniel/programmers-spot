using Moq;
using NUnit.Framework;
using ProgrammersSpot.Business.Data.Contracts;
using System;

namespace ProgrammersSpot.Business.Services.Tests.LocationServiceTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void CreateNewLocationService_WhenParamsAreValid()
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

            //Act & Assert
            Assert.IsInstanceOf<LocationService>(locationService);
        }

        [Test]
        public void ThrowNullException_WhenCountryRepositoryIsNull()
        {
            //Arrange
            var mockedCountryRepository = (ICountryRepository)null;
            var mockedCityRepository = new Mock<ICityRepository>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() =>
                new LocationService(
                    mockedCountryRepository,
                    mockedCityRepository.Object,
                    mockedUnitOfWork.Object
                )
            );
        }

        [Test]
        public void ThrowNullException_WhenCityRepositoryIsNull()
        {
            //Arrange
            var mockedCountryRepository = new Mock<ICountryRepository>();
            var mockedCityRepository = (ICityRepository)null;
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() =>
                new LocationService(
                    mockedCountryRepository.Object,
                    mockedCityRepository,
                    mockedUnitOfWork.Object
                )
            );
        }

        [Test]
        public void ThrowNullException_WhenUnitOfWorkIsNull()
        {
            //Arrange
            var mockedCountryRepository = new Mock<ICountryRepository>();
            var mockedCityRepository = new Mock<ICityRepository>();
            var mockedUnitOfWork = (IUnitOfWork)null;

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() =>
                new LocationService(
                    mockedCountryRepository.Object,
                    mockedCityRepository.Object,
                    mockedUnitOfWork
                )
            );
        }
    }
}
