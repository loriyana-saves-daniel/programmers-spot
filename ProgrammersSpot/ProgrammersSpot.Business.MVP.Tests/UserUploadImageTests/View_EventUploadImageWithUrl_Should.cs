using Moq;
using NUnit.Framework;
using ProgrammersSpot.Business.Models.UploadedImages;
using ProgrammersSpot.Business.MVP.Args;
using ProgrammersSpot.Business.MVP.Presenters;
using ProgrammersSpot.Business.MVP.ViewModels;
using ProgrammersSpot.Business.MVP.Views;
using ProgrammersSpot.Business.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersSpot.Business.MVP.Tests.UserUploadImageTests
{
    [TestFixture]
    public class View_EventUploadImageWithUrl_Should
    {
        [Test]
        public void CallUploadedImageServiceUploadImage_WhenEventIsRaised()
        {
            //Arrange
            var viewMock = new Mock<IUserUploadImageView>();
            viewMock.Setup(v => v.Model).Returns(new UploadImageViewModel());
            var uploadedImageServiceMock = new Mock<IUploadedImageService>();
            var userServiceMock = new Mock<IUserService>();
            string anyString = It.IsAny<string>();

            var presenter = new UserUploadImagePresenter(viewMock.Object, uploadedImageServiceMock.Object, userServiceMock.Object);

            //Act
            viewMock.Raise(v => v.UploadImageWithUrl += null, new UserUploadImageEventArgs());

            //Assert
            uploadedImageServiceMock.Verify(s => s.UploadImage(anyString, anyString, anyString, null), Times.Once);
        }

        [Test]
        public void SetViewModelSucceededToTrue_WhenEventIsRaised()
        {
            //Arrange
            var viewMock = new Mock<IUserUploadImageView>();
            viewMock.Setup(v => v.Model).Returns(new UploadImageViewModel());
            var uploadedImageServiceMock = new Mock<IUploadedImageService>();
            var userServiceMock = new Mock<IUserService>();
            string anyString = It.IsAny<string>();

            var presenter = new UserUploadImagePresenter(viewMock.Object, uploadedImageServiceMock.Object, userServiceMock.Object);

            //Act
            viewMock.Raise(v => v.UploadImageWithUrl += null, new UserUploadImageEventArgs());

            //Assert
            Assert.IsTrue(viewMock.Object.Model.Succeeded);
        }
    }
}
