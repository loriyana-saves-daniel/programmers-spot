using NUnit.Framework;
using ProgrammersSpot.Business.Models.Users;
using System.Collections.Generic;
using ProgrammersSpot.Business.Models.Reviews;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using ProgrammersSpot.Business.Common;

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
    }
}
