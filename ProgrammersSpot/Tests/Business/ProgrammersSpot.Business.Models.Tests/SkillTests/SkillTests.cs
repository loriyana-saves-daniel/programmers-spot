using NUnit.Framework;
using ProgrammersSpot.Business.Common;
using ProgrammersSpot.Business.Models.Skills;
using ProgrammersSpot.Business.Models.Users;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ProgrammersSpot.Business.Models.Tests.SkillTests
{
    [TestFixture]
    public class SkillTests
    {
        [TestCase(342)]
        [TestCase(2)]
        public void Id_ShouldBeSetAndGottenCorrectly(int skillId)
        {
            // Arrange & Act
            var skill = new Skill() { Id = skillId };

            //Assert
            Assert.AreEqual(skill.Id, skillId);
        }

        [TestCase("eiiee eueieiouheyu")]
        public void SkillName_ShouldBeSetAndGottenCorrectly(string name)
        {
            // Arrange & Act
            var skill = new Skill { Name = name };

            //Assert
            Assert.AreEqual(skill.Name, name);
        }

        [Test]
        public void SkillName_ShouldHaveCorrectMinLength()
        {
            // Arrange
            var nameProperty = typeof(Skill).GetProperty("Name");

            // Act
            var minLengthAttribute = nameProperty.GetCustomAttributes(typeof(MinLengthAttribute), false)
                .Cast<MinLengthAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(minLengthAttribute.Length, Is.Not.Null.And.EqualTo(Constants.MinSkillLength));
        }

        [Test]
        public void SkillName_ShouldHaveCorrectMaxLength()
        {
            // Arrange
            var nameProperty = typeof(Skill).GetProperty("Name");

            // Act
            var maxLengthAttribute = nameProperty.GetCustomAttributes(typeof(MaxLengthAttribute), false)
                .Cast<MaxLengthAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(maxLengthAttribute.Length, Is.Not.Null.And.EqualTo(Constants.MaxSkillLength));
        }

        [TestCase(true)]
        [TestCase(false)]
        public void IsDeleted_ShouldBeSetAndGottenCorrectly(bool isDeleted)
        {
            // Arrange & Act
            var skill = new Skill() { IsDeleted = isDeleted };

            //Assert
            Assert.AreEqual(skill.IsDeleted, isDeleted);
        }

        [Test]
        public void Skill_ShouldHaveParameterlessConstructor()
        {
            // Arrange & Act
            var skill = new Skill();

            // Assert
            Assert.IsInstanceOf<Skill>(skill);
        }

        [Test]
        public void SkillConstructor_ShouldInitializeUsersCollectionCorrectly()
        {
            var skill = new Skill();

            var users = skill.Users;

            Assert.That(users, Is.Not.Null.And.InstanceOf<ICollection<RegularUser>>());
        }

        [TestCase("484873b4b4b374")]
        [TestCase("y43y47364-3743t")]
        public void UsersCollection_ShouldBeSetAndGottenCorrectly(string userId)
        {
            var user = new RegularUser() { Id = userId };
            var set = new List<RegularUser> { user };

            var skill = new Skill { Users = set };

            Assert.AreEqual(skill.Users.First().Id, userId);
        }
    }
}
