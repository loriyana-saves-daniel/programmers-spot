using Moq;
using NUnit.Framework;
using ProgrammersSpot.Business.Data.Contracts;
using ProgrammersSpot.Business.Data.Repositories;
using ProgrammersSpot.Business.Models.Users.Contracts;
using System;
using System.Data.Entity;

namespace ProgrammersSpot.Business.Data.Tests.GenericRepositoryTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ShouldThrowArgumentNullException_WhenDbContextIsNull()
        {
            // Arrange              
            IProgrammersSpotDbContext nullDbContext = null;

            // Act & Assert
            Assert.That(() => new GenericRepository<IRegularUser>(nullDbContext),
                Throws.InstanceOf<ArgumentNullException>().With.Message.Contains("An instance of DbContext is required to use this repository."));
        }

        [Test]
        public void ShouldWorkCorrectly_WhenValidArgumentsPassed()
        {
            // Arrange
            var mockedContext = new Mock<IProgrammersSpotDbContext>();
            var mockedDbSet = new Mock<IDbSet<IRegularUser>>();
            mockedContext.Setup(x => x.Set<IRegularUser>()).Returns(mockedDbSet.Object);

            // Act
            var repository = new GenericRepository<IRegularUser>(mockedContext.Object);

            // Assert
            Assert.IsInstanceOf<IRepository<IRegularUser>>(repository);
        }

        [Test]
        public void ShouldSetContextCorrectly_WhenValidArgumentsArePassed()
        {
            // Arrange
            var mockedContext = new Mock<IProgrammersSpotDbContext>();
            var mockedDbSet = new Mock<IDbSet<IRegularUser>>();
            mockedContext.Setup(x => x.Set<IRegularUser>()).Returns(mockedDbSet.Object);

            // Act
            var repository = new GenericRepository<IRegularUser>(mockedContext.Object);

            // Assert
            Assert.AreSame(repository.DbContext, mockedContext.Object);
        }

        [Test]
        public void ShouldSetDbSetCorrectly_WhenValidArgumentsArePassed()
        {
            // Arrange
            var mockedContext = new Mock<IProgrammersSpotDbContext>();
            var mockedDbSet = new Mock<IDbSet<IRegularUser>>();
            mockedContext.Setup(x => x.Set<IRegularUser>()).Returns(mockedDbSet.Object);

            // Act
            var repository = new GenericRepository<IRegularUser>(mockedContext.Object);

            // Assert
            Assert.AreSame(repository.DbSet, mockedDbSet.Object);
        }
    }
}
