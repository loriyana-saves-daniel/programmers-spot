using Bytes2you.Validation;
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
        private IUploadedImageService uploadedImageService;
        private IUserService userService;

        public UploadImagePresenter(
            IUploadImageView view, 
            IUploadedImageService imageService,
            IUserService userService,
            IImageProcessorService imgProcessorService) 
            : base(view)
        {
            Guard.WhenArgument(imageService, "imageService").IsNull().Throw();
            Guard.WhenArgument(userService, "userService").IsNull().Throw();

            this.uploadedImageService = imageService;
            this.userService = userService;
            this.imageProcessorService = imgProcessorService;
            this.View.EventImageUpload += this.OnImageUpload;
        }

        private void OnImageUpload(object sender, UploadImageEventArgs e)
        {
            int fileLength = e.Image.ContentLength;
            string fileName = e.Image.FileName;
            byte[] photoBytes = new byte[fileLength];
            e.Image.InputStream.Read(photoBytes, 0, fileLength);
            var processedImg = this.imageProcessorService.ProcessImage(photoBytes, 200, 200, Path.GetExtension(fileName), 70);

            var folderName = string.Format("{0:ddMMyy}", DateTime.Now);
            var dirToSaveIn = Path.Combine(Server.MapPath("../Content/Uploaded"), folderName);
            Directory.CreateDirectory(dirToSaveIn);
            
            using (FileStream file = new FileStream((Path.Combine(dirToSaveIn, fileName)), FileMode.Create, System.IO.FileAccess.Write))
            {
                using (processedImg)
                {
                    byte[] bytes = new byte[processedImg.Length];
                    processedImg.Read(bytes, 0, (int)processedImg.Length);
                    file.Write(bytes, 0, bytes.Length);
                    file.Flush();
                }
            }

            try
            {
                var ImgUrl = "https://www.programmersspot.com/Content/Uploaded/" + folderName + "/" + fileName;
                var uploader = this.userService.GetRegularUserById(e.UploaderId);
                this.uploadedImageService.UploadImage(e.ImgTitle, ImgUrl, uploader);

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
