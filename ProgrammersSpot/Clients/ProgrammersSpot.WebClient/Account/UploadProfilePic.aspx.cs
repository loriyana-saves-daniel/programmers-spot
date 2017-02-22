using Microsoft.AspNet.Identity;
using ProgrammersSpot.Business.MVP.Args;
using ProgrammersSpot.Business.MVP.Presenters;
using ProgrammersSpot.Business.MVP.ViewModels;
using ProgrammersSpot.Business.MVP.Views;
using System;
using System.Web;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace ProgrammersSpot.WebClient.Account
{
    [PresenterBinding(typeof(UploadProfilePicPresenter))]
    public partial class UploadProfilePic : MvpPage<UploadImageViewModel>, IUploadProfilePicView
    {
        public event EventHandler<UploadProfilePicEventArgs> EventImageUpload;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.User.Identity.IsAuthenticated)
            {
                Response.Redirect(this.ResolveUrl(string.Format("~/Account/Login?ReturnUrl={0}", HttpUtility.UrlEncode("/Account/Manage"))));
            }

            if (this.Request.Files.Count == 0)
            {
                Response.StatusCode = 400;
                Response.End();
                return;
            }

            var userRole = "";
            if (this.User.IsInRole("User"))
            {
                userRole = "User";
            } 
            else if (this.User.IsInRole("Firm"))
            {
                userRole = "Firm";
            }
            else
            {
                Response.StatusCode = 400;
                Response.End();
                return;
            }

            var file = this.Request.Files[0];
            var args = new UploadProfilePicEventArgs()
            {
                ContentLength = file.ContentLength,
                FileName = file.FileName,
                InputStream = file.InputStream,
                UserRole = userRole,
                UploaderId = this.User.Identity.GetUserId()
            };
            this.EventImageUpload?.Invoke(sender, args);

            Response.ClearContent();
            Response.Expires = -1;
            this.Response.ContentType = "application/json";
            if (!this.Model.Succeeded)
            {
                this.Response.Write(string.Format("{{'ErrorMsg' : '{0}'}}", Business.Common.Constants.FailedUploadMessage));
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