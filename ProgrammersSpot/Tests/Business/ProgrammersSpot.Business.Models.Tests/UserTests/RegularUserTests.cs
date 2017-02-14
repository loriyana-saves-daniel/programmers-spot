using System;
using NUnit.Framework;
using ProgrammersSpot.Business.Models.Users;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using ProgrammersSpot.Business.Common;
using System.Collections.Generic;
using ProgrammersSpot.Business.Models.Reviews;
using ProgrammersSpot.Business.Models.Projects;
using ProgrammersSpot.Business.Models.Skills;
using ProgrammersSpot.Business.Models.Users;

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
        public void FirstName_ShouldBeSetAndGetCorrectly(string testName)
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
        public void LastName_ShouldBeSetAndGetCorrectly(string testName)
        {
            // Arrange & Act
            var user = new RegularUser() { LastName = testName };

            //Assert
            Assert.AreEqual(user.LastName, testName);
        }

        [TestCase(20)]
        [TestCase(45)]
        public void Age_ShouldBeSetAndGetCorrectly(int testAge)
        {
            // Arrange & Act
            var user = new RegularUser() { Age = testAge };

            //Assert
            Assert.AreEqual(user.Age, testAge);
        }

        [TestCase("Junior Developer")]
        [TestCase("Senior QA Engineer")]
        public void JobTitle_ShouldBeSetAndGetCorrectly(string testJobTitle)
        {
            // Arrange & Act
            var user = new RegularUser() { JobTitle = testJobTitle };

            //Assert
            Assert.AreEqual(user.JobTitle, testJobTitle);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void IsDeleted_ShouldBeSetAndGetCorrectly(bool isDeleted)
        {
            // Arrange & Act
            var user = new RegularUser() { IsDeleted = isDeleted };

            //Assert
            Assert.AreEqual(user.IsDeleted, isDeleted);
        }

        [TestCase("37827383hg37362g372")]
        [TestCase("382-82328-j3j3828h")]
        public void Id_ShouldBeSetAndGetCorrectly(string userId)
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

            Assert.That(reviews, Is.Not.Null.And.InstanceOf<ICollection<IReview>>());
        }

        [Test]
        public void RegularUserConstructor_ShouldInitializeProjectsCollectionCorrectly()
        {
            var user = new RegularUser();

            var projects = user.Projects;

            Assert.That(projects, Is.Not.Null.And.InstanceOf<ICollection<IProject>>());
        }

        [Test]
        public void RegularUserConstructor_ShouldInitializeSkillsCollectionCorrectly()
        {
            var user = new RegularUser();

            var skills = user.Skills;

            Assert.That(skills, Is.Not.Null.And.InstanceOf<HashSet<ISkill>>());
        }

        [TestCase(1)]
        [TestCase(342)]
        public void GivenReviewsCollection_ShouldBeSetAndGetCorrectly(int reviewId)
        {
            var review = new Review() { Id = reviewId };
            var set = new List<IReview> { review };

            var user = new RegularUser { GivenReviews = set };

            Assert.AreEqual(user.GivenReviews.First().Id, reviewId);
        }

        [TestCase(1)]
        [TestCase(342)]
        public void ProjectsCollection_ShouldBeSetAndGetCorrectly(int projectId)
        {
            var project = new Project() { Id = projectId };
            var set = new List<IProject> { project };

            var user = new RegularUser { Projects = set };

            Assert.AreEqual(user.Projects.First().Id, projectId);
        }

        [TestCase(1)]
        [TestCase(342)]
        public void SkillsCollection_ShouldBeSetAndGetCorrectly(int skillId)
        {
            var skill = new Skill() { Id = skillId };
            var set = new List<ISkill> { skill };

            var user = new RegularUser { Skills = set };

            Assert.AreEqual(user.Skills.First().Id, skillId);
        }

        [TestCase("dhwdwhddh73783ge3e3ye7")]
        [TestCase("eugete762-2832ydf")]
        public void User_ShouldBeSetAndGetCorrectly(string testUserId)
        {
            // Arrange & Act         
            var user = new User { Id = testUserId };
            var regularUser = new RegularUser { User = user };

            //Assert
            Assert.AreEqual(regularUser.User.Id, testUserId);
        }
    }
}
