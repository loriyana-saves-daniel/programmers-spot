using Bytes2you.Validation;
using ProgrammersSpot.Business.MVP.Args;
using ProgrammersSpot.Business.MVP.Views;
using ProgrammersSpot.Business.Services.Contracts;
using System;
using WebFormsMvp;

namespace ProgrammersSpot.Business.MVP.Presenters
{
    public class TakeABreakPresenter : Presenter<ITakeABreakView>
    {
        protected readonly IUploadedImageService uploadedImageService;

        public TakeABreakPresenter(ITakeABreakView view, IUploadedImageService uploadedImageService) : base(view)
        {
            Guard.WhenArgument(uploadedImageService, "uploadedImageService").IsNull().Throw();

            this.uploadedImageService = uploadedImageService;
            view.EventGetImages += this.OnGetImages;
            view.EventSearchImages += this.OnSearchImages;
            view.ImageLiked += this.OnImageLiked;
            view.ImageDisliked += this.OnImageDisliked;
        }

        private void OnSearchImages(object sender, SearchEventArgs e)
        {
            this.View.Model.UploadedImages = this.uploadedImageService.GetImagesWithTitle(e.QueryParams);
        }

        private void OnGetImages(object sender, EventArgs e)
        {
            this.View.Model.UploadedImages = this.uploadedImageService.GetAllImages();
        }

        private void OnImageLiked(object sender, FormGetItemEventArgs e)
        {
            this.uploadedImageService.LikeImage(e.Id);
        }

        private void OnImageDisliked(object sender, FormGetItemEventArgs e)
        {
            this.uploadedImageService.DislikeImage(e.Id);
        }
    }
}
