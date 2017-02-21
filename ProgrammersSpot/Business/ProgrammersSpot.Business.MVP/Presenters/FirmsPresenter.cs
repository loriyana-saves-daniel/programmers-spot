using Bytes2you.Validation;
using ProgrammersSpot.Business.MVP.Args;
using ProgrammersSpot.Business.MVP.Views;
using ProgrammersSpot.Business.Services.Contracts;
using System;
using WebFormsMvp;

namespace ProgrammersSpot.Business.MVP.Presenters
{
    public class FirmsPresenter : Presenter<IFirmsView>
    {
        private readonly IFirmService firmService;

        public FirmsPresenter(IFirmsView view, IFirmService firmService) : base(view)
        {
            Guard.WhenArgument(firmService, "firmService").IsNull().Throw();

            this.firmService = firmService;

            view.EventGetFirms += this.OnGetFirms;
            view.EventSearchFirms += this.OnSearchFirms;
            //view.ImageLiked += this.OnImageLiked;
            //view.ImageDisliked += this.OnImageDisliked;
        }

        private void OnSearchFirms(object sender, SearchEventArgs e)
        {
            this.View.Model.Firms = this.firmService.GetFirmsWithName(e.QueryParams);
        }

        private void OnGetFirms(object sender, EventArgs e)
        {
            this.View.Model.Firms = this.firmService.GetAllFirmUsers();
        }

        //private void OnImageLiked(object sender, FormGetItemEventArgs e)
        //{
        //    this.uploadedImageService.LikeImage(e.Id);
        //}

        //private void OnImageDisliked(object sender, FormGetItemEventArgs e)
        //{
        //    this.uploadedImageService.DislikeImage(e.Id);
        //}
    }
}
