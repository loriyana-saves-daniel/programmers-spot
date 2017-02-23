using NUnit.Framework;
using ProgrammersSpot.Business.MVP.Presenters;
using ProgrammersSpot.Business.MVP.Tests.Mocks;
using ProgrammersSpot.Business.MVP.Views;
using ProgrammersSpot.Business.Services.Contracts;
using System;
using Moq;

namespace ProgrammersSpot.Business.MVP.Tests.UserUploadImageTests
{
    [TestFixture]
    public class Presenter_Constructor_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenUploadedImageServiceIsNull()
        {
            //Arrange
            var viewMock = new Mock<IUserUploadImageView>();
            var userServiceMock = new Mock<IUserService>();

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => new UserUploadImagePresenter(viewMock.Object, null, userServiceMock.Object));
        }

        [Test]
        public void ThrowArgumentNullException_WhenUserServiceIsNull()
        {
            //Arrange
            var viewMock = new Mock<IUserUploadImageView>();
            var uploadedImageServiceMock = new Mock<IUploadedImageService>();

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => new UserUploadImagePresenter(viewMock.Object, uploadedImageServiceMock.Object, null));
        }

        [Test]
        public void NotThrow_WhenValidParametersArePassed()
        {
            //Arrange
            var viewMock = new Mock<IUserUploadImageView>();
            var uploadedImageServiceMock = new Mock<IUploadedImageService>();
            var userServiceMock = new Mock<IUserService>();

            //Act & Assert
            Assert.DoesNotThrow(() => new UserUploadImagePresenter(viewMock.Object, uploadedImageServiceMock.Object, userServiceMock.Object));
        }

        [Test]
        public void InstantiateCorrectly_WhenValidParametersArePassed()
        {
            //Arrange
            var viewMock = new Mock<IUserUploadImageView>();
            var uploadedImageServiceMock = new Mock<IUploadedImageService>();
            var userServiceMock = new Mock<IUserService>();
            
            //Act
            var presenter = new UserUploadImagePresenterMock(viewMock.Object, uploadedImageServiceMock.Object, userServiceMock.Object);

            //Assert
            Assert.AreSame(uploadedImageServiceMock.Object, presenter.UploadedImageService);
            Assert.AreSame(userServiceMock.Object, presenter.UserService);
        }
    }
}
