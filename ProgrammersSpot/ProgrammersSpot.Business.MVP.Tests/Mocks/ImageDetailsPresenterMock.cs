using ProgrammersSpot.Business.MVP.Presenters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgrammersSpot.Business.MVP.Views;
using ProgrammersSpot.Business.Services.Contracts;

namespace ProgrammersSpot.Business.MVP.Tests.Mocks
{
    public class ImageDetailsPresenterMock : ImageDetailsPresenter
    {
        public ImageDetailsPresenterMock(IImageDetailsView view, IUploadedImageService uploadedImageService) : base(view, uploadedImageService)
        {
        }

        public IUploadedImageService UploadedImageService
        {
            get
            {
                return this.uploadedImageService;
            }
        }
    }
}
