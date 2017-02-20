using Bytes2you.Validation;
using ProgrammersSpot.Business.MVP.Views;
using ProgrammersSpot.Business.Services;
using ProgrammersSpot.Business.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;
using ProgrammersSpot.Business.MVP.Args;

namespace ProgrammersSpot.Business.MVP.Presenters
{
    public class ImageDetailsPresenter : Presenter<IImageDetailsView>
    {
        private readonly IUploadedImageService uploadedImageService;

        public ImageDetailsPresenter(IImageDetailsView view, IUploadedImageService uploadedImageService) 
            : base(view)
        {
            Guard.WhenArgument(uploadedImageService, "uploadedImageService").IsNull().Throw();

            this.uploadedImageService = uploadedImageService;
            view.EventGetImage += this.OnGetImage;
            view.ImageCommented += this.OnImageCommented;
            view.ImageLiked += this.OnImageLiked;
            view.ImageDisliked += this.OnImageDisliked;
        }

        private void OnImageDisliked(object sender, FormGetItemEventArgs e)
        {
            this.uploadedImageService.DislikeImage(e.Id);
        }

        private void OnImageLiked(object sender, FormGetItemEventArgs e)
        {
            this.uploadedImageService.LikeImage(e.Id);
        }

        private void OnImageCommented(object sender, ImageCommentEventArgs e)
        {
            this.uploadedImageService.CommentImage(e.ImageId, e.Comment, e.AuthorId);
        }

        private void OnGetImage(object sender, FormGetItemEventArgs e)
        {
            this.View.Model.Image = this.uploadedImageService.GetImageById(e.Id);
        }
    }
}
