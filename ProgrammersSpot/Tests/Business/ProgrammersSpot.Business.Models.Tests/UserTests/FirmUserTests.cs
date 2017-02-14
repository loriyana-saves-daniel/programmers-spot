using NUnit.Framework;
using ProgrammersSpot.Business.Models.Users;
using System.Collections.Generic;
using ProgrammersSpot.Business.Models.Reviews;
using System.Linq;

namespace ProgrammersSpot.Business.Models.Tests.UserTests
{
    [TestFixture]
    public class FirmUserTests
    {
        [TestCase("37827383hg37362g372")]
        [TestCase("382-82328-j3j3828h")]
        public void Id_ShouldBeSetAndGetCorrectly(string firmId)
        {
            // Arrange & Act
            var firm = new FirmUser() { Id = firmId };

            //Assert
            Assert.AreEqual(firm.Id, firmId);
        }

        [TestCase("dhwdwhddh73783ge3e3ye7")]
        [TestCase("eugete762-2832ydf")]
        public void User_ShouldBeSetAndGetCorrectly(string testUserId)
        {
            // Arrange & Act         
            var user = new User { Id = testUserId };
            var firm = new FirmUser { User = user };

            //Assert
            Assert.AreEqual(firm.User.Id, testUserId);
        }

        [TestCase("Al. Malinov")]
        [TestCase("Lozenec")]
        public void Address_ShouldBeSetAndGetCorrectly(string address)
        {
            // Arrange & Act
            var firm = new FirmUser() { Address = address };

            //Assert
            Assert.AreEqual(firm.Address, address);
        }

        [TestCase(21)]
        [TestCase(4566)]
        public void EmployeesCount_ShouldBeSetAndGetCorrectly(int employeesCount)
        {
            // Arrange & Act
            var firm = new FirmUser() { EmployeesCount = employeesCount };

            //Assert
            Assert.AreEqual(firm.EmployeesCount, employeesCount);
        }

        [TestCase(10)]
        [TestCase(6)]
        public void Rating_ShouldBeSetAndGetCorrectly(int rating)
        {
            // Arrange & Act
            var firm = new FirmUser() { Rating = rating };

            //Assert
            Assert.AreEqual(firm.Rating, rating);
        }

        [TestCase("www.telerik.com")]
        [TestCase("www.vmware.com")]
        public void Website_ShouldBeSetAndGetCorrectly(string website)
        {
            // Arrange & Act
            var firm = new FirmUser() { Website = website };

            //Assert
            Assert.AreEqual(firm.Website, website);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void IsDeleted_ShouldBeSetAndGetCorrectly(bool isDeleted)
        {
            // Arrange & Act
            var firm = new FirmUser() { IsDeleted = isDeleted };

            //Assert
            Assert.AreEqual(firm.IsDeleted, isDeleted);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void IsApproved_ShouldBeSetAndGetCorrectly(bool isApproved)
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

            Assert.That(reviews, Is.Not.Null.And.InstanceOf<ICollection<IReview>>());
        }

        [TestCase(87)]
        [TestCase(342)]
        public void FirmReviewsCollection_ShouldBeSetAndGetCorrectly(int reviewId)
        {
            var review = new Review() { Id = reviewId };
            var set = new List<IReview> { review };

            var firm = new FirmUser { FirmReviews = set };

            Assert.AreEqual(firm.FirmReviews.First().Id, reviewId);
        }
    }
}
