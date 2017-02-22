using NUnit.Framework;
using Moq;
using ProgrammersSpot.Business.Data.Contracts;

namespace ProgrammersSpot.Business.Data.Tests.UnitOfWorkTests
{
    [TestFixture]
    public class SaveChanges_Should
    {
        [Test]
        public void InvokeDbContextOnce()
        {
            var mockedContext = new Mock<IProgrammersSpotDbContext>();
            var unitOfWork = new ProgrammersSpot.Business.Data.UnitOfWork.UnitOfWork(mockedContext.Object);

            unitOfWork.SaveChanges();

            mockedContext.Verify(mock => mock.SaveChanges(), Times.Once());
        }
    }
}
