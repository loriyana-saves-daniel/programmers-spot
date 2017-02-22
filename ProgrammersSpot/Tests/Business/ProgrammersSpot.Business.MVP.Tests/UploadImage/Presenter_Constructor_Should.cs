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

namespace ProgrammersSpot.Business.MVP.Tests.UploadImage
{
    [TestFixture]
    public class Presenter_Constructor_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenUploadedImageServiceIsNull()
        {
            //Arrange
            var viewMock = new Mock<IUploadImageView>();
            var imageProcessorServiceMock = new Mock<IImageProcessorService>();
            var userServiceMock = new Mock<IUserService>();
            var fileSaverServiceMock = new Mock<IFileSaverService>();

            //Act & Assert
            Assert.Throws<ArgumentNullException>(
                () => new UploadImagePresenter(viewMock.Object, null, userServiceMock.Object, imageProcessorServiceMock.Object, fileSaverServiceMock.Object));
        }

        [Test]
        public void ThrowArgumentNullException_WhenUserServiceIsNull()
        {
            //Arrange
            var viewMock = new Mock<IUploadImageView>();
            var imageProcessorServiceMock = new Mock<IImageProcessorService>();
            var uploadedImageServiceMock = new Mock<IUploadedImageService>();
            var fileSaverServiceMock = new Mock<IFileSaverService>();

            //Act & Assert
            Assert.Throws<ArgumentNullException>(
                () => new UploadImagePresenter(viewMock.Object, uploadedImageServiceMock.Object, null, imageProcessorServiceMock.Object, fileSaverServiceMock.Object));
        }

        [Test]
        public void ThrowArgumentNullException_WhenImageProcessorServiceIsNull()
        {
            //Arrange
            var viewMock = new Mock<IUploadImageView>();
            var uploadedImageServiceMock = new Mock<IUploadedImageService>();
            var userServiceMock = new Mock<IUserService>();
            var fileSaverServiceMock = new Mock<IFileSaverService>();

            //Act & Assert
            Assert.Throws<ArgumentNullException>(
                () => new UploadImagePresenter(viewMock.Object, uploadedImageServiceMock.Object, userServiceMock.Object, null, fileSaverServiceMock.Object));
        }

        [Test]
        public void ThrowArgumentNullException_WhenFileSaverServiceIsNull()
        {
            //Arrange
            var viewMock = new Mock<IUploadImageView>();
            var imageProcessorServiceMock = new Mock<IImageProcessorService>();
            var userServiceMock = new Mock<IUserService>();
            var uploadedImageService = new Mock<IUploadedImageService>();

            //Act & Assert
            Assert.Throws<ArgumentNullException>(
                () => new UploadImagePresenter(viewMock.Object, uploadedImageService.Object, userServiceMock.Object, imageProcessorServiceMock.Object, null));
        }

        [Test]
        public void DoesNotThrow_WhenValidParametersArePassed()
        {
            //Arrange
            var viewMock = new Mock<IUploadImageView>();
            var imageProcessorServiceMock = new Mock<IImageProcessorService>();
            var userServiceMock = new Mock<IUserService>();
            var uploadedImageServiceMock = new Mock<IUploadedImageService>();
            var fileSaverMock = new Mock<IFileSaverService>();

            //Act & Assert
            Assert.DoesNotThrow(() => new UploadImagePresenterMock(
                viewMock.Object, uploadedImageServiceMock.Object, userServiceMock.Object, imageProcessorServiceMock.Object, fileSaverMock.Object));
        }

        [Test]
        public void InstantiateCorrectly_WhenValidParametersArePassed()
        {
            //Arrange
            var viewMock = new Mock<IUploadImageView>();
            var imageProcessorServiceMock = new Mock<IImageProcessorService>();
            var userServiceMock = new Mock<IUserService>();
            var uploadedImageServiceMock = new Mock<IUploadedImageService>();
            var fileSaverMock = new Mock<IFileSaverService>();

            //Act
            var presenter = new UploadImagePresenterMock(
                viewMock.Object, uploadedImageServiceMock.Object, userServiceMock.Object, imageProcessorServiceMock.Object, fileSaverMock.Object);

            //Assert
            Assert.AreSame(uploadedImageServiceMock.Object, presenter.UploadedImageService);
            Assert.AreSame(userServiceMock.Object, presenter.UserService);
            Assert.AreSame(fileSaverMock.Object, presenter.FileSaverService);
            Assert.AreSame(imageProcessorServiceMock.Object, presenter.ImageProcessorService);
        }
    }
}
