using Bytes2you.Validation;
using ProgrammersSpot.Business.MVP.Args;
using ProgrammersSpot.Business.MVP.Views;
using ProgrammersSpot.Business.Services.Contracts;
using System.Data.SqlClient;
using WebFormsMvp;

namespace ProgrammersSpot.Business.MVP.Presenters
{
    public class UserUploadImagePresenter : Presenter<IUserUploadImageView>
    {
        protected IUploadedImageService uploadedImageService;
        protected IUserService userService;

        public UserUploadImagePresenter(
            IUserUploadImageView view, 
            IUploadedImageService imageService, 
            IUserService userService) 
            : base(view)
        {
            Guard.WhenArgument(imageService, "uploadedImageService").IsNull().Throw();
            Guard.WhenArgument(userService, "userService").IsNull().Throw();

            this.uploadedImageService = imageService;
            this.userService = userService;
            view.UploadImageWithUrl += this.OnUploadImageWithUrl;
        }

        private void OnUploadImageWithUrl(object sender, UserUploadImageEventArgs e)
        {
            try
            {
                var uploader = this.userService.GetRegularUserById(e.UploaderId);
                this.uploadedImageService.UploadImage(e.ImgTitle, e.ImgUrl, e.ImgUrl, uploader);

                this.View.Model.Succeeded = true;
            }
            catch (SqlException ex)
            {
                this.View.Model.ErrorMessage = ex.Message;
                this.View.Model.Succeeded = false;
            }
        }
    }
}
