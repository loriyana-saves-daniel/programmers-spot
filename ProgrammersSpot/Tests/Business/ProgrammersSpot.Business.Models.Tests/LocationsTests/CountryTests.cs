using NUnit.Framework;
using ProgrammersSpot.Business.Common;
using ProgrammersSpot.Business.Models.Locations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ProgrammersSpot.Business.Models.Tests.LocationsTests
{
    [TestFixture]
    public class CountryTests
    {
        [TestCase(342)]
        [TestCase(2)]
        public void Id_ShouldBeSetAndGottenCorrectly(int countryId)
        {
            // Arrange & Act
            var country = new Country() { Id = countryId };

            //Assert
            Assert.AreEqual(country.Id, countryId);
        }

        [TestCase("eiiee eueieiouheyu")]
        public void CountryName_ShouldBeSetAndGottenCorrectly(string name)
        {
            // Arrange & Act
            var country = new Country { Name = name };

            //Assert
            Assert.AreEqual(country.Name, name);
        }

        [Test]
        public void CountryName_ShouldHaveCorrectMinLength()
        {
            // Arrange
            var nameProperty = typeof(Country).GetProperty("Name");

            // Act
            var minLengthAttribute = nameProperty.GetCustomAttributes(typeof(MinLengthAttribute), false)
                .Cast<MinLengthAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(minLengthAttribute.Length, Is.Not.Null.And.EqualTo(Constants.NameMinLength));
        }

        [Test]
        public void CountryName_ShouldHaveCorrectMaxLength()
        {
            // Arrange
            var nameProperty = typeof(Country).GetProperty("Name");

            // Act
            var maxLengthAttribute = nameProperty.GetCustomAttributes(typeof(MaxLengthAttribute), false)
                .Cast<MaxLengthAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(maxLengthAttribute.Length, Is.Not.Null.And.EqualTo(Constants.NameMaxLength));
        }

        [Test]
        public void Country_ShouldHaveParameterlessConstructor()
        {
            // Arrange & Act
            var country = new Country();

            // Assert
            Assert.IsInstanceOf<Country>(country);
        }

        [Test]
        public void CountryConstructor_ShouldInitializeCitiesCollectionCorrectly()
        {
            var country = new Country();

            var users = country.Cities;

            Assert.That(users, Is.Not.Null.And.InstanceOf<ICollection<City>>());
        }

        [TestCase(456)]
        [TestCase(21)]
        public void CitiesCollection_ShouldBeSetAndGottenCorrectly(int cityId)
        {
            var city = new City() { Id = cityId };
            var set = new List<City> { city };

            var country = new Country { Cities = set };

            Assert.AreEqual(country.Cities.First().Id, cityId);
        }
    }
}
