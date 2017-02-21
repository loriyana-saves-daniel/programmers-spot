using Microsoft.AspNet.Identity;
using ProgrammersSpot.Business.MVP.Args;
using ProgrammersSpot.Business.MVP.Presenters;
using ProgrammersSpot.Business.MVP.ViewModels;
using ProgrammersSpot.Business.MVP.Views;
using System;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace ProgrammersSpot.WebClient.TakeABreak
{
    [PresenterBinding(typeof(UploadImagePresenter))]
    public partial class UploadImage : MvpPage<UploadImageViewModel>, IUploadImageView
    {
        public event EventHandler<UploadImageEventArgs> EventImageUpload;

        protected void Page_Load(object sender, EventArgs e)
        {
            var args = new UploadImageEventArgs()
            {
                ImgTitle = this.Request.Headers["image-title"],
                Image = this.Request.Files[0],
                UploaderId = this.User.Identity.GetUserId()
            };
            this.EventImageUpload?.Invoke(sender, args);

            if (!this.Model.Succeeded)
            {
                this.Response.Write(this.Model.ErrorMessage);
            }
            else
            {
                this.Response.ContentType = "application/json";
                this.Response.Write("{}");
            }
        }
    }
}