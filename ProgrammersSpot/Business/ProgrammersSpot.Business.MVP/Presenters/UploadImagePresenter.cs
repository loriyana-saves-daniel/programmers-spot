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
    public class UploadImagePresenter : Presenter<IUploadImageView>
    {
        private IImageProcessorService imageProcessorService;
        private IFileSaverService fileSaverService;
        private IUploadedImageService uploadedImageService;
        private IUserService userService;

        public UploadImagePresenter(
            IUploadImageView view, 
            IUploadedImageService imageService,
            IUserService userService,
            IImageProcessorService imgProcessorService,
            IFileSaverService fileSaverService) 
            : base(view)
        {
            Guard.WhenArgument(imageService, "imageProcessorService").IsNull().Throw();
            Guard.WhenArgument(userService, "userService").IsNull().Throw();
            Guard.WhenArgument(fileSaverService, "fileSaverService").IsNull().Throw();

            this.uploadedImageService = imageService;
            this.userService = userService;
            this.fileSaverService = fileSaverService;
            this.imageProcessorService = imgProcessorService;
            this.View.EventImageUpload += this.OnImageUpload;
        }

        private void OnImageUpload(object sender, UploadImageEventArgs e)
        {
            int fileLength = e.Image.ContentLength;
            string fileName = e.Image.FileName;
            byte[] photoBytes = new byte[fileLength];
            e.Image.InputStream.Read(photoBytes, 0, fileLength);
            var folderName = string.Format("{0:ddMMyy}", DateTime.Now);

            try
            {
                // processing image
                var processedImgThumbnail = this.imageProcessorService.ProcessImage(
                    photoBytes, 
                    Constants.TakeABrakeThumbnailImageSize, 
                    Constants.TakeABrakeThumbnailImageSize, 
                    Path.GetExtension(fileName), 
                    Constants.ThumbnailImageQualityPercentage);
                var processedImgOriginal = this.imageProcessorService.ProcessImage(
                    photoBytes,
                    Constants.TakeABrakeOriginalImageSize,
                    Constants.TakeABrakeOriginalImageSize,
                    Path.GetExtension(fileName),
                    Constants.OriginalImageQualityPercentage);

                // saving images
                var dirToSaveInThumbnail = Path.Combine(Server.MapPath("../" + Constants.ContentUploadedTakeABreakThumbnailsRelPath), folderName);
                var dirToSaveInOriginal = Path.Combine(Server.MapPath("../" + Constants.ContentUploadedTakeABreakOriginalsRelPath), folderName);

                fileName = this.fileSaverService.SaveFile(processedImgThumbnail, dirToSaveInThumbnail, fileName);
                fileName = this.fileSaverService.SaveFile(processedImgOriginal, dirToSaveInOriginal, fileName);
            }
            catch (Exception ex)
            {
                this.View.Model.ErrorMessage = ex.Message;
                this.View.Model.Succeeded = false;
            }
            
            // saving image urls to db
            try
            {
                var thumbnailImgUrl = Constants.ProgrammersSpotUrl + Constants.ContentUploadedTakeABreakThumbnailsRelPath + folderName + "/" + fileName;
                var originalImgUrl = Constants.ProgrammersSpotUrl + Constants.ContentUploadedTakeABreakOriginalsRelPath + folderName + "/" + fileName;
                var uploader = this.userService.GetRegularUserById(e.UploaderId);
                this.uploadedImageService.UploadImage(e.ImgTitle, thumbnailImgUrl, originalImgUrl, uploader);

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
