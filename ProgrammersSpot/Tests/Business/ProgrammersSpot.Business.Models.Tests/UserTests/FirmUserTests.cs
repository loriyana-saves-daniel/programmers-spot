using NUnit.Framework;
using ProgrammersSpot.Business.Common;
using ProgrammersSpot.Business.Models.Locations;
using ProgrammersSpot.Business.Models.Reviews;
using ProgrammersSpot.Business.Models.Users;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ProgrammersSpot.Business.Models.Tests.UserTests
{
    [TestFixture]
    public class FirmUserTests
    {
        [TestCase("37827383hg37362g372")]
        [TestCase("382-82328-j3j3828h")]
        public void Id_ShouldBeSetAndGottenCorrectly(string firmId)
        {
            // Arrange & Act
            var firm = new FirmUser() { Id = firmId };

            //Assert
            Assert.AreEqual(firm.Id, firmId);
        }

        [TestCase("Telerik")]
        [TestCase("Progress")]
        public void FirmName_ShouldBeSetAndGottenCorrectly(string name)
        {
            // Arrange & Act
            var firm = new FirmUser() { FirmName = name };

            //Assert
            Assert.AreEqual(firm.FirmName, name);
        }

        [TestCase("dhwdwhddh73783ge3e3ye7")]
        [TestCase("eugete762-2832ydf")]
        public void User_ShouldBeSetAndGottenCorrectly(string testUserId)
        {
            // Arrange & Act         
            var user = new User { Id = testUserId };
            var firm = new FirmUser { User = user };

            //Assert
            Assert.AreEqual(firm.User.Id, testUserId);
        }

        [TestCase("Al. Malinov")]
        [TestCase("Lozenec")]
        public void Address_ShouldBeSetAndGottenCorrectly(string address)
        {
            // Arrange & Act
            var firm = new FirmUser() { Address = address };

            //Assert
            Assert.AreEqual(firm.Address, address);
        }

        [Test]
        public void Address_ShouldHaveCorrectMinLength()
        {
            // Arrange
            var addressProperty = typeof(FirmUser).GetProperty("Address");

            // Act
            var minLengthAttribute = addressProperty.GetCustomAttributes(typeof(MinLengthAttribute), false)
                .Cast<MinLengthAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(minLengthAttribute.Length, Is.Not.Null.And.EqualTo(Constants.MinAddressLength));
        }

        [Test]
        public void Address_ShouldHaveCorrectMaxLength()
        {
            // Arrange
            var addressProperty = typeof(FirmUser).GetProperty("Address");

            // Act
            var maxLengthAttribute = addressProperty.GetCustomAttributes(typeof(MaxLengthAttribute), false)
                .Cast<MaxLengthAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(maxLengthAttribute.Length, Is.Not.Null.And.EqualTo(Constants.MaxAddressLength));
        }

        [TestCase(21)]
        [TestCase(4566)]
        public void EmployeesCount_ShouldBeSetAndGottenCorrectly(int employeesCount)
        {
            // Arrange & Act
            var firm = new FirmUser() { EmployeesCount = employeesCount };

            //Assert
            Assert.AreEqual(firm.EmployeesCount, employeesCount);
        }

        [TestCase(10)]
        [TestCase(6)]
        public void Rating_ShouldBeSetAndGottenCorrectly(int rating)
        {
            // Arrange & Act
            var firm = new FirmUser() { Rating = rating };

            //Assert
            Assert.AreEqual(firm.Rating, rating);
        }

        [TestCase("www.telerik.com")]
        [TestCase("www.vmware.com")]
        public void Website_ShouldBeSetAndGottenCorrectly(string website)
        {
            // Arrange & Act
            var firm = new FirmUser() { Website = website };

            //Assert
            Assert.AreEqual(firm.Website, website);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void IsDeleted_ShouldBeSetAndGottenCorrectly(bool isDeleted)
        {
            // Arrange & Act
            var firm = new FirmUser() { IsDeleted = isDeleted };

            //Assert
            Assert.AreEqual(firm.IsDeleted, isDeleted);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void IsApproved_ShouldBeSetAndGottenCorrectly(bool isApproved)
        {
            // Arrange & Act
            var firm = new FirmUser() { IsApproved = isApproved };

            //Assert
            Assert.AreEqual(firm.IsApproved, isApproved);
        }

        [Test]
        public void FirmUser_ShouldHaveParameterlessConstructor()
        {
            // Arrange & Act
            var firm = new FirmUser();

            // Assert
            Assert.IsInstanceOf<FirmUser>(firm);
        }

        [Test]
        public void FirmUserConstructor_ShouldInitializeFirmReviewsCollectionCorrectly()
        {
            var firm = new FirmUser();

            var reviews = firm.FirmReviews;

            Assert.That(reviews, Is.Not.Null.And.InstanceOf<ICollection<Review>>());
        }

        [TestCase(87)]
        [TestCase(342)]
        public void FirmReviewsCollection_ShouldBeSetAndGottenCorrectly(int reviewId)
        {
            var review = new Review() { Id = reviewId };
            var set = new List<Review> { review };

            var firm = new FirmUser { FirmReviews = set };

            Assert.AreEqual(firm.FirmReviews.First().Id, reviewId);
        }

        [TestCase(234)]
        [TestCase(2)]
        public void Country_ShouldBeSetAndGottenCorrectly(int testCountryId)
        {
            // Arrange & Act         
            var country = new Country { Id = testCountryId };
            var firm = new FirmUser { Country = country };

            //Assert
            Assert.AreEqual(firm.Country.Id, testCountryId);
        }

        [TestCase(3)]
        [TestCase(236)]
        public void CointryId_ShouldBeSetAndGottenCorrectly(int countryId)
        {
            // Arrange & Act
            var firm = new FirmUser { CountryId = countryId };

            //Assert
            Assert.AreEqual(countryId, firm.CountryId);
        }

        [TestCase(234)]
        [TestCase(2)]
        public void City_ShouldBeSetAndGottenCorrectly(int testCityId)
        {
            // Arrange & Act         
            var city = new City { Id = testCityId };
            var firm = new FirmUser { City = city };

            //Assert
            Assert.AreEqual(firm.City.Id, testCityId);
        }

        [TestCase(3)]
        [TestCase(236)]
        public void CityId_ShouldBeSetAndGottenCorrectly(int cityId)
        {
            // Arrange & Act
            var firm = new FirmUser { CityId = cityId };

            //Assert
            Assert.AreEqual(cityId, firm.CityId);
        }
    }
}
