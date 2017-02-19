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

        public ImageDetailsPresenter(IImageDetailsView view, IUploadedImageService uploadedImageService) : base(view)
        {
            Guard.WhenArgument(uploadedImageService, "uploadedImageService").IsNull().Throw();

            this.uploadedImageService = uploadedImageService;
            view.EventGetImage += this.OnGetImage;
        }

        private void OnGetImage(object sender, FormGetItemEventArgs e)
        {
            this.View.Model.Image = this.uploadedImageService.GetImageById(e.Id);
        }
    }
}
