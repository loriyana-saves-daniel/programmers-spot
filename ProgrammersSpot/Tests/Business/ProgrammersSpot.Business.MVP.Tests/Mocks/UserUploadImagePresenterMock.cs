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
    public class UserUploadImagePresenterMock : UserUploadImagePresenter
    {
        public UserUploadImagePresenterMock(IUserUploadImageView view, IUploadedImageService imageService, IUserService userService) 
            : base(view, imageService, userService)
        {
        }

        public IUploadedImageService UploadedImageService
        {
            get
            {
                return this.uploadedImageService;
            }
        }

        public IUserService UserService
        {
            get
            {
                return this.userService;
            }
        }
    }
}
