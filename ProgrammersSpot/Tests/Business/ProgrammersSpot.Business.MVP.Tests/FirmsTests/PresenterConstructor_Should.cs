using System;
using NUnit.Framework;
using Moq;
using ProgrammersSpot.Business.MVP.Views;
using ProgrammersSpot.Business.Services.Contracts;
using ProgrammersSpot.Business.MVP.Presenters;
using ProgrammersSpot.Business.MVP.Tests.Mocks;

namespace ProgrammersSpot.Business.MVP.Tests.FirmsTests
{
    [TestFixture]
    public class PresenterConstructor_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenFirmServiceIsNull()
        {
            //Arrange
            var viewMock = new Mock<IFirmsView>();

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => new FirmsPresenter(viewMock.Object, null));
        }

        [Test]
        public void NotThrow_WhenValidParametersArePassed()
        {
            //Arrange
            var viewMock = new Mock<IFirmsView>();
            var firmServiceMock = new Mock<IFirmService>();

            //Act & Assert
            Assert.DoesNotThrow(() => new FirmsPresenter(viewMock.Object, firmServiceMock.Object));
        }

        [Test]
        public void InstantiateCorrectly_WhenValidParametersArePassed()
        {
            //Arrange
            var viewMock = new Mock<IFirmsView>();
            var firmServiceMock = new Mock<IFirmService>();

            //Act
            var presenter = new FirmsPresenterMock(viewMock.Object, firmServiceMock.Object);

            //Assert
            Assert.AreSame(firmServiceMock.Object, presenter.FirmService);
        }
    }
}
