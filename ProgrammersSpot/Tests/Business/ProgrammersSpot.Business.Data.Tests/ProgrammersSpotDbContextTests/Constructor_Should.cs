using Moq;
using NUnit.Framework;
using ProgrammersSpot.Business.Data.Contracts;
using ProgrammersSpot.Business.Models.Locations;
using ProgrammersSpot.Business.Models.UserRoles;
using ProgrammersSpot.Business.Models.Users;
using ProgrammersSpot.Business.Services;

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
