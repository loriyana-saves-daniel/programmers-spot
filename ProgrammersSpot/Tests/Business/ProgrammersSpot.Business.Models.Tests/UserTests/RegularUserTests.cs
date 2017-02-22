using NUnit.Framework;
using ProgrammersSpot.Business.Common;
using ProgrammersSpot.Business.Models.Projects;
using ProgrammersSpot.Business.Models.Reviews;
using ProgrammersSpot.Business.Models.Skills;
using ProgrammersSpot.Business.Models.UploadedImages;
using ProgrammersSpot.Business.Models.Users;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ProgrammersSpot.Business.Models.Tests.UserTests
{
    [TestFixture]
    public class RegularUserTests
    {
        [Test]
        public void FirstName_ShouldHaveCorrectMinLength()
        {
            // Arrange
            var firstNameProperty = typeof(RegularUser).GetProperty("FirstName");

            // Act
            var minLengthAttribute = firstNameProperty.GetCustomAttributes(typeof(MinLengthAttribute), false)
                .Cast<MinLengthAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(minLengthAttribute.Length, Is.Not.Null.And.EqualTo(Constants.NameMinLength));
        }

        [Test]
        public void FirstName_ShouldHaveCorrectMaxLength()
        {
            // Arrange
            var firstNameProperty = typeof(RegularUser).GetProperty("FirstName");

            // Act
            var maxLengthAttribute = firstNameProperty.GetCustomAttributes(typeof(MaxLengthAttribute), false)
                .Cast<MaxLengthAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(maxLengthAttribute.Length, Is.Not.Null.And.EqualTo(Constants.NameMaxLength));
        }

        [TestCase("Ivan")]
        [TestCase("Blagoi")]
        public void FirstName_ShouldBeSetAndGottenCorrectly(string testName)
        {
            // Arrange & Act
            var user = new RegularUser() { FirstName = testName };

            //Assert
            Assert.AreEqual(user.FirstName, testName);
        }

        [Test]
        public void LastName_ShouldHaveCorrectMinLength()
        {
            // Arrange
            var lastNameProperty = typeof(RegularUser).GetProperty("LastName");

            // Act
            var minLengthAttribute = lastNameProperty.GetCustomAttributes(typeof(MinLengthAttribute), false)
                .Cast<MinLengthAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(minLengthAttribute.Length, Is.Not.Null.And.EqualTo(Constants.NameMinLength));
        }

        [Test]
        public void LastName_ShouldHaveCorrectMaxLength()
        {
            // Arrange
            var lastNameProperty = typeof(RegularUser).GetProperty("LastName");

            // Act
            var maxLengthAttribute = lastNameProperty.GetCustomAttributes(typeof(MaxLengthAttribute), false)
                .Cast<MaxLengthAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(maxLengthAttribute.Length, Is.Not.Null.And.EqualTo(Constants.NameMaxLength));
        }

        [TestCase("Ivanov")]
        [TestCase("Georgiev")]
        public void LastName_ShouldBeSetAndGottenCorrectly(string testName)
        {
            // Arrange & Act
            var user = new RegularUser() { LastName = testName };

            //Assert
            Assert.AreEqual(user.LastName, testName);
        }

        [TestCase(20)]
        [TestCase(45)]
        public void Age_ShouldBeSetAndGottenCorrectly(int testAge)
        {
            // Arrange & Act
            var user = new RegularUser() { Age = testAge };

            //Assert
            Assert.AreEqual(user.Age, testAge);
        }

        [TestCase(20)]
        [TestCase(45)]
        public void StarsCount_ShouldBeSetAndGottenCorrectly(int count)
        {
            // Arrange & Act
            var user = new RegularUser() { StarsCount = count };

            //Assert
            Assert.AreEqual(user.StarsCount, count);
        }

        [TestCase("Junior Developer")]
        [TestCase("Senior QA Engineer")]
        public void JobTitle_ShouldBeSetAndGottenCorrectly(string testJobTitle)
        {
            // Arrange & Act
            var user = new RegularUser() { JobTitle = testJobTitle };

            //Assert
            Assert.AreEqual(user.JobTitle, testJobTitle);
        }

        [TestCase("Content/image.png")]
        public void AvatarUrl_ShouldBeSetAndGottenCorrectly(string avatar)
        {
            // Arrange & Act
            var user = new RegularUser() { AvatarUrl = avatar };

            //Assert
            Assert.AreEqual(user.AvatarUrl, avatar);
        }

        [TestCase("pesho@abv.bg")]
        public void Email_ShouldBeSetAndGottenCorrectly(string email)
        {
            // Arrange & Act
            var user = new RegularUser() { Email = email };

            //Assert
            Assert.AreEqual(user.Email, email);
        }

        [TestCase("github.com/pesho")]
        public void GitHubProfile_ShouldBeSetAndGottenCorrectly(string github)
        {
            // Arrange & Act
            var user = new RegularUser() { GitHubProfile = github };

            //Assert
            Assert.AreEqual(user.GitHubProfile, github);
        }

        [TestCase("facebook.com/pesho")]
        public void FacebookProfile_ShouldBeSetAndGottenCorrectly(string fb)
        {
            // Arrange & Act
            var user = new RegularUser() { FacebookProfile = fb };

            //Assert
            Assert.AreEqual(user.FacebookProfile, fb);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void IsDeleted_ShouldBeSetAndGottenCorrectly(bool isDeleted)
        {
            // Arrange & Act
            var user = new RegularUser() { IsDeleted = isDeleted };

            //Assert
            Assert.AreEqual(user.IsDeleted, isDeleted);
        }

        [TestCase("37827383hg37362g372")]
        [TestCase("382-82328-j3j3828h")]
        public void Id_ShouldBeSetAndGottenCorrectly(string userId)
        {
            // Arrange & Act
            var user = new RegularUser() { Id = userId };

            //Assert
            Assert.AreEqual(user.Id, userId);
        }

        [Test]
        public void RegularUser_ShouldHaveParameterlessConstructor()
        {
            // Arrange & Act
            var user = new RegularUser();

            // Assert
            Assert.IsInstanceOf<RegularUser>(user);
        }

        [Test]
        public void RegularUserConstructor_ShouldInitializeGivenReviewsCollectionCorrectly()
        {
            var user = new RegularUser();

            var reviews = user.GivenReviews;

            Assert.That(reviews, Is.Not.Null.And.InstanceOf<ICollection<Review>>());
        }

        [Test]
        public void RegularUserConstructor_ShouldInitializeStarredUsersCollectionCorrectly()
        {
            var user = new RegularUser();

            var starredUsers = user.StarredUsers;

            Assert.That(starredUsers, Is.Not.Null.And.InstanceOf<ICollection<RegularUser>>());
        }

        [Test]
        public void RegularUserConstructor_ShouldInitializeStarredFirmsCollectionCorrectly()
        {
            var user = new RegularUser();

            var starredFirms = user.StarredFirms;

            Assert.That(starredFirms, Is.Not.Null.And.InstanceOf<ICollection<FirmUser>>());
        }

        [Test]
        public void RegularUserConstructor_ShouldInitializeUploadedImagesCollectionCorrectly()
        {
            var user = new RegularUser();

            var images = user.UploadedImages;

            Assert.That(images, Is.Not.Null.And.InstanceOf<ICollection<UploadedImage>>());
        }

        [Test]
        public void RegularUserConstructor_ShouldInitializeProjectsCollectionCorrectly()
        {
            var user = new RegularUser();

            var projects = user.Projects;

            Assert.That(projects, Is.Not.Null.And.InstanceOf<ICollection<Project>>());
        }

        [Test]
        public void RegularUserConstructor_ShouldInitializeSkillsCollectionCorrectly()
        {
            var user = new RegularUser();

            var skills = user.Skills;

            Assert.That(skills, Is.Not.Null.And.InstanceOf<HashSet<Skill>>());
        }

        [TestCase(1)]
        [TestCase(342)]
        public void GivenReviewsCollection_ShouldBeSetAndGottenCorrectly(int reviewId)
        {
            var review = new Review() { Id = reviewId };
            var set = new List<Review> { review };

            var user = new RegularUser { GivenReviews = set };

            Assert.AreEqual(user.GivenReviews.First().Id, reviewId);
        }

        [TestCase("3")]
        [TestCase("389729872bb7z2b2b2743763v6v3x64734555y")]
        public void StarredFirmsCollection_ShouldBeSetAndGottenCorrectly(string firmId)
        {
            var firm = new FirmUser() { Id = firmId };
            var set = new List<FirmUser> { firm };

            var user = new RegularUser { StarredFirms = set };

            Assert.AreEqual(user.StarredFirms.First().Id, firmId);
        }

        [TestCase("3")]
        [TestCase("389729872bb7z2b2b2743763v6v3x64734555y")]
        public void StarredUsersCollection_ShouldBeSetAndGottenCorrectly(string userId)
        {
            var user = new RegularUser() { Id = userId };
            var set = new List<RegularUser> { user };

            var user2 = new RegularUser { StarredUsers = set };

            Assert.AreEqual(user2.StarredUsers.First().Id, userId);
        }

        [TestCase(3)]
        [TestCase(323232)]
        public void UploadedImagesCollection_ShouldBeSetAndGottenCorrectly(int imageId)
        {
            var image = new UploadedImage() { Id = imageId };
            var set = new List<UploadedImage> { image };

            var user = new RegularUser { UploadedImages = set };

            Assert.AreEqual(user.UploadedImages.First().Id, imageId);
        }

        [TestCase(1)]
        [TestCase(342)]
        public void ProjectsCollection_ShouldBeSetAndGottenCorrectly(int projectId)
        {
            var project = new Project() { Id = projectId };
            var set = new List<Project> { project };

            var user = new RegularUser { Projects = set };

            Assert.AreEqual(user.Projects.First().Id, projectId);
        }

        [TestCase(1)]
        [TestCase(342)]
        public void SkillsCollection_ShouldBeSetAndGottenCorrectly(int skillId)
        {
            var skill = new Skill() { Id = skillId };
            var set = new List<Skill> { skill };

            var user = new RegularUser { Skills = set };

            Assert.AreEqual(user.Skills.First().Id, skillId);
        }

        [TestCase("dhwdwhddh73783ge3e3ye7")]
        [TestCase("eugete762-2832ydf")]
        public void User_ShouldBeSetAndGottenCorrectly(string testUserId)
        {
            // Arrange & Act         
            var user = new User { Id = testUserId };
            var regularUser = new RegularUser { User = user };

            //Assert
            Assert.AreEqual(regularUser.User.Id, testUserId);
        }
    }
}
