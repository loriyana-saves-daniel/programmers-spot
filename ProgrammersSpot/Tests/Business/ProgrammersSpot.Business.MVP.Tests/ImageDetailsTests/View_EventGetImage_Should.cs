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

namespace ProgrammersSpot.Business.MVP.Tests.ImageDetailsTests
{
    [TestFixture]
    public class View_EventGetImage_Should
    {
        [Test]
        public void AddUploadedImagesToViewModel_WhenRaised()
        {
            //Arrange
            var viewMock = new Mock<IImageDetailsView>();
            viewMock.Setup(v => v.Model).Returns(new ImageDetailsViewModel());

            var uploadedImageService = new Mock<IUploadedImageService>();
            var uploadedImage = new UploadedImage()
                {
                    Id = 1,
                    Title = "Title1"
                };

            uploadedImageService.Setup(s => s.GetImageById(It.IsAny<int>())).Returns(uploadedImage);

            var presenter = new ImageDetailsPresenter(viewMock.Object, uploadedImageService.Object);

            //Act
            viewMock.Raise(v => v.EventGetImage += null, new FormGetItemEventArgs(It.IsAny<int>()));

            //Assert
            Assert.AreSame(uploadedImage, viewMock.Object.Model.Image);
        }
    }
}
