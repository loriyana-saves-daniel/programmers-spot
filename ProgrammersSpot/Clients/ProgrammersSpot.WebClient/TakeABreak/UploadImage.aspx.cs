using Microsoft.AspNet.Identity;
using ProgrammersSpot.Business.MVP.Args;
using ProgrammersSpot.Business.MVP.Presenters;
using ProgrammersSpot.Business.MVP.ViewModels;
using ProgrammersSpot.Business.MVP.Views;
using System;
using System.Web;
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
            if (!this.User.Identity.IsAuthenticated)
            {
                Response.Redirect(this.ResolveUrl(string.Format("~/Account/Login?ReturnUrl={0}", HttpUtility.UrlEncode("/TakeABreak/UserUploadImage"))));
            }

            if (this.Request.Files.Count == 0)
            {
                Response.StatusCode = 400;
                Response.End();
                return;
            }

            var file = this.Request.Files[0];
            var args = new UploadImageEventArgs()
            {
                ImgTitle = this.Request.Headers["image-title"],
                ContentLength = file.ContentLength,
                InputStream = file.InputStream,
                FileName = file.FileName,
                UploaderId = this.User.Identity.GetUserId()
            };
            this.EventImageUpload?.Invoke(sender, args);

            Response.ClearContent();
            Response.Expires = -1;
            this.Response.ContentType = "application/json";
            if (!this.Model.Succeeded)
            {
                this.Response.Write(string.Format("{'ErrorMsg' : '{0}'}", Business.Common.Constants.FailedUploadMessage));
                this.Response.End();
            }
            else
            {
                this.Response.Write("{}");
                this.Response.End();
            }
        }
    }
}