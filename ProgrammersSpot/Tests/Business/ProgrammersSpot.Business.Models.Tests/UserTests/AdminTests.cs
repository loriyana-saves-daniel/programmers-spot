using NUnit.Framework;
using ProgrammersSpot.Business.Models.Users;
using System.Collections.Generic;
using System.Linq;

namespace ProgrammersSpot.Business.Models.Tests.UserTests
{
    [TestFixture]
    public class AdminTests
    {
        [TestCase("37827383hg37362g372")]
        [TestCase("382-82328-j3j3828h")]
        public void Id_ShouldBeSetAndGottenCorrectly(string adminId)
        {
            // Arrange & Act
            var admin = new Admin() { Id = adminId };

            //Assert
            Assert.AreEqual(admin.Id, adminId);
        }

        [TestCase("dhwdwhddh73783ge3e3ye7")]
        [TestCase("eugete762-2832ydf")]
        public void User_ShouldBeSetAndGottenCorrectly(string testUserId)
        {
            // Arrange & Act         
            var user = new User { Id = testUserId };
            var admin = new Admin { User = user };

            //Assert
            Assert.AreEqual(admin.User.Id, testUserId);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void IsDeleted_ShouldBeSetAndGottenCorrectly(bool isDeleted)
        {
            // Arrange & Act
            var admin = new Admin() { IsDeleted = isDeleted };

            //Assert
            Assert.AreEqual(admin.IsDeleted, isDeleted);
        }

        [Test]
        public void Admin_ShouldHaveParameterlessConstructor()
        {
            // Arrange & Act
            var admin = new Admin();

            // Assert
            Assert.IsInstanceOf<Admin>(admin);
        }

        [Test]
        public void AdminConstructor_ShouldInitializeFirmRegistrationRequestsCollectionCorrectly()
        {
            var admin = new Admin();

            var firmRegistrationRequests = admin.FirmRegistrationRequests;

            Assert.That(firmRegistrationRequests, Is.Not.Null.And.InstanceOf<ICollection<FirmUser>>());
        }

        [TestCase("3737883jh3bu38")]
        [TestCase("838287fb-3738h")]
        public void FirmRegistrationRequestsCollection_ShouldBeSetAndGottenCorrectly(string firmUserId)
        {
            var firm = new FirmUser() { Id = firmUserId };
            var set = new List<FirmUser> { firm };

            var admin = new Admin { FirmRegistrationRequests = set };

            Assert.AreEqual(admin.FirmRegistrationRequests.First().Id, firmUserId);
        }
    }
}
