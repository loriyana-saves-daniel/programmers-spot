using NUnit.Framework;
using ProgrammersSpot.Business.Data.Contracts;

namespace ProgrammersSpot.Business.Data.Tests.ProgrammersSpotDbContextTests
{
    [TestFixture]
    public class Create_Should
    {
        [Test]
        public void ReturnProgrammersSpotDbContextInstance()
        {
            // Arrange & Act
            var dbContext = ProgrammersSpotDbContext.Create();

            // Assert
            Assert.IsInstanceOf<IProgrammersSpotDbContext>(dbContext);
        }
    }
}
