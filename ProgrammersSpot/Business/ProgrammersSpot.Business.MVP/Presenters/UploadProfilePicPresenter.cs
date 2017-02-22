using Bytes2you.Validation;
using ProgrammersSpot.Business.Common;
using ProgrammersSpot.Business.MVP.Args;
using ProgrammersSpot.Business.MVP.Views;
using ProgrammersSpot.Business.Services.Contracts;
using System;
using System.Data.SqlClient;
using System.IO;
using WebFormsMvp;

namespace ProgrammersSpot.Business.MVP.Presenters
{
    public class UploadProfilePicPresenter : Presenter<IUploadProfilePicView>
    {
        private IFileSaverService fileSaverService;
        private IImageProcessorService imageProcessorService;
        private IUserService userService;
        private IFirmService firmService;

        public UploadProfilePicPresenter(
            IUploadProfilePicView view,
            IUserService userService,
            IFirmService firmService,
            IImageProcessorService imgProcessorService,
            IFileSaverService fileSaverService) 
            : base(view)
        {
            Guard.WhenArgument(userService, "userService").IsNull().Throw();
            Guard.WhenArgument(firmService, "firmService").IsNull().Throw();
            Guard.WhenArgument(imgProcessorService, "imageProcessorService").IsNull().Throw();
            Guard.WhenArgument(fileSaverService, "fileSaverService").IsNull().Throw();
            
            this.userService = userService;
            this.firmService = firmService;
            this.fileSaverService = fileSaverService;
            this.imageProcessorService = imgProcessorService;
            this.View.EventImageUpload += this.OnImageUpload;
        }

        private void OnImageUpload(object sender, UploadProfilePicEventArgs e)
        {
            int fileLength = e.ContentLength;
            string fileName = "avatar" + Path.GetExtension(e.FileName);
            var folderName = e.UploaderId;

            byte[] photoBytes = new byte[fileLength];
            e.InputStream.Read(photoBytes, 0, fileLength);

            // saving image
            try
            {
                var processedImg = this.imageProcessorService.ProcessImage(
                    photoBytes,
                    Constants.ThumbnailImageSize,
                    Constants.ThumbnailImageSize,
                    Path.GetExtension(fileName),
                    Constants.ThumbnailImageQualityPercentage);

                var dirToSaveIn = Path.Combine(Server.MapPath("../" + Constants.ContentUploadedProfilesRelPath), folderName);

                this.fileSaverService.SaveFile(processedImg, dirToSaveIn, fileName, true);
            }
            catch (Exception ex)
            {
                this.View.Model.ErrorMessage = ex.Message;
                this.View.Model.Succeeded = false;
                return;
            }

            // saving image url to db
            try
            {
                var imgUrl = Constants.ProgrammersSpotUrl + Constants.ContentUploadedProfilesRelPath + folderName + "/" + fileName;
                var uploader = this.userService.GetRegularUserById(e.UploaderId);
                if (e.UserRole == "User")
                {
                    this.userService.UpdateRegularUserAvatarUrl(e.UploaderId, imgUrl);
                }
                else if (e.UserRole == "Firm")
                {
                    this.firmService.UpdateFirmUserAvatarUrl(e.UploaderId, imgUrl);
                }
                else
                {
                    this.View.Model.Succeeded = false;
                    this.View.Model.ErrorMessage = "Unable to find user.";
                    return;
                }

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
