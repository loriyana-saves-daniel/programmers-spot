using NUnit.Framework;
using ProgrammersSpot.Business.Models.UserRoles;

namespace ProgrammersSpot.Business.Models.Tests.UserRoleTests
{
    [TestFixture]
    public class RoleTests
    {
        [Test]
        public void Role_ShouldHaveParameterlessConstructor()
        {
            // Arrange & Act
            var role = new Role();

            // Assert
            Assert.IsInstanceOf<Role>(role);
        }

        [TestCase("Firm")]
        [TestCase("User")]
        public void Role_ShouldHaveConstructorWithNameParameter(string roleName)
        {
            // Arrange & Act
            var role = new Role(roleName);

            // Assert
            Assert.IsInstanceOf<Role>(role);
            Assert.AreEqual(role.Name, roleName);
        }

        [TestCase("eiiee eueieiouheyu")]
        public void RoleDescription_ShouldBeSetAndGottenCorrectly(string description)
        {
            // Arrange & Act
            var role = new Role { Description = description };

            //Assert
            Assert.AreEqual(role.Description, description);
        }
    }
}
