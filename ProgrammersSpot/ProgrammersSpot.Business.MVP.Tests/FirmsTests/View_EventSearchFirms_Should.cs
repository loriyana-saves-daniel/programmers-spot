using Moq;
using NUnit.Framework;
using ProgrammersSpot.Business.Models.Users;
using ProgrammersSpot.Business.MVP.Args;
using ProgrammersSpot.Business.MVP.Presenters;
using ProgrammersSpot.Business.MVP.ViewModels;
using ProgrammersSpot.Business.MVP.Views;
using ProgrammersSpot.Business.Services.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace ProgrammersSpot.Business.MVP.Tests.FirmsTests
{
    [TestFixture]
    public class View_EventSearchImages_Should
    {
        [Test]
        public void AddFoundFirmsToViewModel_WhenRaised()
        {
            //Arrange
            var viewMock = new Mock<IFirmsView>();
            viewMock.Setup(v => v.Model).Returns(new FirmsViewModel());

            var firmService = new Mock<IFirmService>();
            var firms = new List<FirmUser>()
            {
                new FirmUser()
                {
                    Id = "1",
                    Email = "email1"
                },
                new FirmUser()
                {
                    Id = "2",
                    Email = "Email"
                },
                new FirmUser()
                {
                    Id = "3",
                    Email = "Title3"
                }
            }.AsQueryable();
            string keyword = It.IsAny<string>();
            firmService.Setup(s => s.GetFirmsWithName(keyword)).Returns(firms);

            var presenter = new FirmsPresenter(viewMock.Object, firmService.Object);

            //Act
            viewMock.Raise(v => v.EventSearchFirms += null, new SearchEventArgs(keyword));

            //Assert
            CollectionAssert.AreEquivalent(firms, viewMock.Object.Model.Firms);
        }
    }
}
