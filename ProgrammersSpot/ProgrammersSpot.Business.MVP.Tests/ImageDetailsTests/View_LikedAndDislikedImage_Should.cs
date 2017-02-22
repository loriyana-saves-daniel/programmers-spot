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
        //[Test]
        //public void CallUploadedImageServiceOnce_WhenLikedImageEventIsRaised()
        //{
        //    //Arrange
        //    var viewMock = new Mock<ITakeABreakView>();
        //    var uploadedImageService = new Mock<IUploadedImageService>();
        //    var presenter = new TakeABreakPresenter(viewMock.Object, uploadedImageService.Object);

        //    //Act
        //    viewMock.Raise(v => v.ImageLiked += null, new FormGetItemEventArgs(It.IsAny<int>()));

        //    //Assert
        //    uploadedImageService.Verify(m => m.LikeImage(It.IsAny<int>()), Times.Once);
        //}

        //[Test]
        //public void CallUploadedImageServiceOnce_WhenDislikedImageEventIsRaised()
        //{
        //    //Arrange
        //    var viewMock = new Mock<ITakeABreakView>();
        //    var uploadedImageService = new Mock<IUploadedImageService>();
        //    var presenter = new TakeABreakPresenter(viewMock.Object, uploadedImageService.Object);

        //    //Act
        //    viewMock.Raise(v => v.ImageDisliked += null, new FormGetItemEventArgs(It.IsAny<int>()));

        //    //Assert
        //    uploadedImageService.Verify(m => m.DislikeImage(It.IsAny<int>()), Times.Once);
        //}
    }
}
