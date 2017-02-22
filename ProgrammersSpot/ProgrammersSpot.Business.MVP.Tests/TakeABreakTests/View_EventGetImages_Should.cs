using Moq;
using NUnit.Framework;
using ProgrammersSpot.Business.Models.UploadedImages;
using ProgrammersSpot.Business.MVP.Presenters;
using ProgrammersSpot.Business.MVP.ViewModels;
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
    public class View_EventGetImages_Should
    {
        [Test]
        public void AddUploadedImagesToViewModel_WhenRaised()
        {
            //Arrange
            var viewMock = new Mock<ITakeABreakView>();
            viewMock.Setup(v => v.Model).Returns(new TakeABreakViewModel());

            var uploadedImageService = new Mock<IUploadedImageService>();
            var uploadedImages = new List<UploadedImage>()
            {
                new UploadedImage()
                {
                    Id = 1,
                    Title = "Title1"
                },
                new UploadedImage()
                {
                    Id = 2,
                    Title = "Title2"
                },
                new UploadedImage()
                {
                    Id = 3,
                    Title = "Title3"
                }
            }.AsQueryable();
            uploadedImageService.Setup(s => s.GetAllImages()).Returns(uploadedImages);

            var presenter = new TakeABreakPresenter(viewMock.Object, uploadedImageService.Object);

            //Act
            viewMock.Raise(v => v.EventGetImages += null, EventArgs.Empty);

            //Assert
            CollectionAssert.AreEquivalent(uploadedImages, viewMock.Object.Model.UploadedImages);
        }
    }
}
