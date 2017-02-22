using Moq;
using NUnit.Framework;
using ProgrammersSpot.Business.MVP.Presenters;
using ProgrammersSpot.Business.MVP.Tests.Mocks;
using ProgrammersSpot.Business.MVP.Views;
using ProgrammersSpot.Business.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersSpot.Business.MVP.Tests.TakeABreakTests
{
    [TestFixture]
    public class Presenter_Constructor_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenUploadedImageServiceIsNull()
        {
            //Arrange
            var viewMock = new Mock<ITakeABreakView>();

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => new TakeABreakPresenter(viewMock.Object, null));
        }

        [Test]
        public void NotThrow_WhenValidParametersArePassed()
        {
            //Arrange
            var viewMock = new Mock<ITakeABreakView>();
            var uploadedImageServiceMock = new Mock<IUploadedImageService>();

            //Act & Assert
            Assert.DoesNotThrow(() => new TakeABreakPresenter(viewMock.Object, uploadedImageServiceMock.Object));
        }

        [Test]
        public void InstantiateCorrectly_WhenValidParametersArePassed()
        {
            //Arrange
            var viewMock = new Mock<ITakeABreakView>();
            var uploadedImageServiceMock = new Mock<IUploadedImageService>();

            //Act
            var presenter = new TakeABreakPresenterMock(viewMock.Object, uploadedImageServiceMock.Object);

            //Assert
            Assert.AreSame(uploadedImageServiceMock.Object, presenter.UploadedImageService);
        }
    }
}
