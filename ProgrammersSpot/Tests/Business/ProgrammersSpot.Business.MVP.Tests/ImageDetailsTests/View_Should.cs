using Moq;
using NUnit.Framework;
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

namespace ProgrammersSpot.Business.MVP.Tests.ImageDetailsTests
{
    [TestFixture]
    public class View_Should
    {
        [Test]
        public void CallUploadedImageServiceLikeImageOnce_WhenImageLikedEventIsRaised()
        {
            //Arrange
            var viewMock = new Mock<IImageDetailsView>();
            var uploadedImageService = new Mock<IUploadedImageService>();
            var presenter = new ImageDetailsPresenter(viewMock.Object, uploadedImageService.Object);

            //Act
            viewMock.Raise(v => v.ImageLiked += null, new FormGetItemEventArgs(It.IsAny<int>()));

            //Assert
            uploadedImageService.Verify(m => m.LikeImage(It.IsAny<int>()), Times.Once);
        }

        [Test]
        public void CallUploadedImageServiceDislikeImageOnce_WhenImageDislikedEventIsRaised()
        {
            //Arrange
            var viewMock = new Mock<IImageDetailsView>();
            var uploadedImageService = new Mock<IUploadedImageService>();
            var presenter = new ImageDetailsPresenter(viewMock.Object, uploadedImageService.Object);

            //Act
            viewMock.Raise(v => v.ImageDisliked += null, new FormGetItemEventArgs(It.IsAny<int>()));

            //Assert
            uploadedImageService.Verify(m => m.DislikeImage(It.IsAny<int>()), Times.Once);
        }

        [Test]
        public void CallUploadedImageServiceCommentImageOnce_WhenCommentedImageEventIsRaised()
        {
            //Arrange
            var viewMock = new Mock<IImageDetailsView>();
            var uploadedImageService = new Mock<IUploadedImageService>();
            var presenter = new ImageDetailsPresenter(viewMock.Object, uploadedImageService.Object);

            //Act
            viewMock.Raise(v => v.ImageCommented += null, new ImageCommentEventArgs());

            //Assert
            uploadedImageService.Verify(m => m.CommentImage(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }
    }
}
