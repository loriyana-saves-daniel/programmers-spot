using Moq;
using NUnit.Framework;
using ProgrammersSpot.Business.Common;
using ProgrammersSpot.Business.MVP.Args;
using ProgrammersSpot.Business.MVP.Presenters;
using ProgrammersSpot.Business.MVP.ViewModels;
using ProgrammersSpot.Business.MVP.Views;
using ProgrammersSpot.Business.Services.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ProgrammersSpot.Business.MVP.Tests.UploadImage
{
    [TestFixture]
    public class View_EventImageUpload_Should
    {
        [Test]
        public void CallImageProcessorServiceProcessImageTwice_WhenEventIsRaised()
        {
            //Arrange
            var viewMock = new Mock<IUploadImageView>();
            viewMock.Setup(v => v.Model).Returns(new UploadImageViewModel());
            var imageProcessorServiceMock = new Mock<IImageProcessorService>();
            var userServiceMock = new Mock<IUserService>();
            var uploadedImageServiceMock = new Mock<IUploadedImageService>();
            var fileSaverMock = new Mock<IFileSaverService>();
            int anyInt = It.IsAny<int>();

            var args = new UploadImageEventArgs()
            {
                ContentLength = anyInt,
                FileName = It.IsAny<string>(),
                InputStream = Stream.Null
            };

            var presenter = new UploadImagePresenter(
                viewMock.Object, uploadedImageServiceMock.Object, userServiceMock.Object, imageProcessorServiceMock.Object, fileSaverMock.Object);

            //Act
            viewMock.Raise(v => v.EventImageUpload += null, args);

            //Assert
            imageProcessorServiceMock.Verify(s => s.ProcessImage(
                new byte[anyInt], Constants.ThumbnailImageSize, Constants.ThumbnailImageSize, null, Constants.ThumbnailImageQualityPercentage), Times.Once);
            imageProcessorServiceMock.Verify(s => s.ProcessImage(
                new byte[anyInt], Constants.LargeImageSize, Constants.LargeImageSize, null, Constants.OriginalImageQualityPercentage), Times.Once);
        }

        [Test]
        public void UpdateViewModel_WhenEventIsRaised()
        {
            //Arrange
            var viewMock = new Mock<IUploadImageView>();
            viewMock.Setup(v => v.Model).Returns(new UploadImageViewModel());
            var imageProcessorServiceMock = new Mock<IImageProcessorService>();
            var userServiceMock = new Mock<IUserService>();
            var uploadedImageServiceMock = new Mock<IUploadedImageService>();
            var fileSaverMock = new Mock<IFileSaverService>();
            int anyInt = It.IsAny<int>();

            var args = new UploadImageEventArgs()
            {
                ContentLength = anyInt,
                FileName = It.IsAny<string>(),
                InputStream = Stream.Null
            };

            var presenter = new UploadImagePresenter(
                viewMock.Object, uploadedImageServiceMock.Object, userServiceMock.Object, imageProcessorServiceMock.Object, fileSaverMock.Object);

            //Act
            viewMock.Raise(v => v.EventImageUpload += null, args);

            //Assert
            Assert.IsFalse(viewMock.Object.Model.Succeeded);
            Assert.IsNotNull(viewMock.Object.Model.ErrorMessage);
        }
    }
}
