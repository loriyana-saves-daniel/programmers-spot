using System;
using NUnit.Framework;
using ProgrammersSpot.Business.Data.Contracts;
using Moq;

namespace ProgrammersSpot.Business.Data.Tests.UnitOfWorkTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenDbContextParameterIsNull()
        {
            IProgrammersSpotDbContext nullContext = null;

            Assert.That(
                () => new ProgrammersSpot.Business.Data.UnitOfWork.UnitOfWork(nullContext),
                Throws.InstanceOf<ArgumentNullException>().With.Message.Contains("Db context"));
        }

        [Test]
        public void ShouldWork_WhenParametersAreValid()
        {
            var mockDbContext = new Mock<IProgrammersSpotDbContext>();

            var uow = new ProgrammersSpot.Business.Data.UnitOfWork.UnitOfWork(mockDbContext.Object);

            Assert.IsNotNull(uow);
        }

        [Test]
        public void CreateUowThatImplementsIDisposableAndIUnitOfWork_WhenParametersAreValid()
        {
            var mockDbContext = new Mock<IProgrammersSpotDbContext>();

            var uow = new ProgrammersSpot.Business.Data.UnitOfWork.UnitOfWork(mockDbContext.Object);

            Assert.IsInstanceOf<IDisposable>(uow);
            Assert.IsInstanceOf<IUnitOfWork>(uow);
        }
    }
}
