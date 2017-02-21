using NUnit.Framework;
using ProgrammersSpot.Business.Data.Contracts;

namespace ProgrammersSpot.Business.Data.Tests.ProgrammersSpotDbContextTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void Return_InstanceOfIProgrammersSpotDbContext()
        {
            // Arange
            var dbContext = new ProgrammersSpotDbContext();

            // Act & Assert
            Assert.IsInstanceOf<IProgrammersSpotDbContext>(dbContext);
        }
    }
}
