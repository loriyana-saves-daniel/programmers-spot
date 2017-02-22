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
    public class UploadImagePresenterMock : UploadImagePresenter
    {
        public UploadImagePresenterMock(IUploadImageView view, IUploadedImageService imageService, IUserService userService, IImageProcessorService imgProcessorService, IFileSaverService fileSaverService) : base(view, imageService, userService, imgProcessorService, fileSaverService)
        {
        }

        public IUploadedImageService UploadedImageService
        {
            get
            {
                return this.uploadedImageService;
            }
        }

        public IImageProcessorService ImageProcessorService
        {
            get
            {
                return this.imageProcessorService;
            }
        }

        public IUserService UserService
        {
            get
            {
                return this.userService;
            }
        }

        public IFileSaverService FileSaverService
        {
            get
            {
                return this.fileSaverService;
            }
        }
    }
}
