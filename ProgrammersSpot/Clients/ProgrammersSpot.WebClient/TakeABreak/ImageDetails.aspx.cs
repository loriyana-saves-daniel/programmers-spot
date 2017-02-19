using ProgrammersSport.Business.Models.UploadedImages;
using ProgrammersSpot.Business.MVP.Args;
using ProgrammersSpot.Business.MVP.Presenters;
using ProgrammersSpot.Business.MVP.ViewModels;
using ProgrammersSpot.Business.MVP.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace ProgrammersSpot.WebClient.TakeABreak
{
    [PresenterBinding(typeof(ImageDetailsPresenter))]
    public partial class ImageDetails : MvpPage<ImageDetailsViewModel>, IImageDetailsView
    {
        public event EventHandler<FormGetItemEventArgs> EventGetImage;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public UploadedImage FormViewImageDetails_GetItem([QueryString] int id)
        {
            this.EventGetImage?.Invoke(this, new FormGetItemEventArgs(id));

            return this.Model.Image;
        }
    }
}