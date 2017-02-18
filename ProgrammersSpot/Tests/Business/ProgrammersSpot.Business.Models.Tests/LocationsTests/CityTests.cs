using NUnit.Framework;
using ProgrammersSpot.Business.Common;
using ProgrammersSpot.Business.Models.Locations;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ProgrammersSpot.Business.Models.Tests.LocationsTests
{
    [TestFixture]
    public class CityTests
    {
        [TestCase(342)]
        [TestCase(2)]
        public void Id_ShouldBeSetAndGottenCorrectly(int cityId)
        {
            // Arrange & Act
            var city = new City() { Id = cityId };

            //Assert
            Assert.AreEqual(city.Id, cityId);
        }

        [TestCase("eiiee eueieiouheyu")]
        public void CityName_ShouldBeSetAndGottenCorrectly(string name)
        {
            // Arrange & Act
            var city = new City { Name = name };

            //Assert
            Assert.AreEqual(city.Name, name);
        }

        [Test]
        public void CityName_ShouldHaveCorrectMinLength()
        {
            // Arrange
            var nameProperty = typeof(City).GetProperty("Name");

            // Act
            var minLengthAttribute = nameProperty.GetCustomAttributes(typeof(MinLengthAttribute), false)
                .Cast<MinLengthAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(minLengthAttribute.Length, Is.Not.Null.And.EqualTo(Constants.NameMinLength));
        }

        [Test]
        public void CityName_ShouldHaveCorrectMaxLength()
        {
            // Arrange
            var nameProperty = typeof(City).GetProperty("Name");

            // Act
            var maxLengthAttribute = nameProperty.GetCustomAttributes(typeof(MaxLengthAttribute), false)
                .Cast<MaxLengthAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(maxLengthAttribute.Length, Is.Not.Null.And.EqualTo(Constants.NameMaxLength));
        }

        [TestCase(234)]
        [TestCase(2)]
        public void Country_ShouldBeSetAndGottenCorrectly(int testCountryId)
        {
            // Arrange & Act         
            var country = new Country { Id = testCountryId };
            var city = new City { Country = country };

            //Assert
            Assert.AreEqual(city.Country.Id, testCountryId);
        }

        [TestCase(3)]
        [TestCase(236)]
        public void CointryId_ShouldBeSetAndGottenCorrectly(int countryId)
        {
            // Arrange & Act
            var city = new City { CountryId = countryId };

            //Assert
            Assert.AreEqual(countryId, city.CountryId);
        }
    }
}
