using Microsoft.AspNet.Identity;
using ProgrammersSpot.Business.Models.UploadedImages;
using ProgrammersSpot.Business.MVP.Args;
using ProgrammersSpot.Business.MVP.Presenters;
using ProgrammersSpot.Business.MVP.ViewModels;
using ProgrammersSpot.Business.MVP.Views;
using System;
using System.Web;
using System.Web.UI.WebControls;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace ProgrammersSpot.WebClient.TakeABreak
{
    [PresenterBinding(typeof(ImageDetailsPresenter))]
    public partial class ImageDetails : MvpPage<ImageDetailsViewModel>, IImageDetailsView
    {
        public event EventHandler<FormGetItemEventArgs> EventGetImage;
        public event EventHandler<ImageCommentEventArgs> ImageCommented;
        public event EventHandler<FormGetItemEventArgs> ImageLiked;
        public event EventHandler<FormGetItemEventArgs> ImageDisliked;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                int id = -1;
                if (int.TryParse(Request.QueryString["id"], out id))
                {
                    this.EventGetImage?.Invoke(this, new FormGetItemEventArgs(id));
                    return;
                }
            }

            Response.StatusCode = 404;
        }

        public UploadedImage FormViewImageDetails_GetItem()
        {
            return this.Model.Image;
        }

        protected void LinkButtonLike_Click(object sender, EventArgs e)
        {
            if (!this.User.Identity.IsAuthenticated)
            {
                Response.Redirect(this.ResolveUrl(string.Format(
                    "~/Account/Login?ReturnUrl={0}{1}", 
                    HttpUtility.UrlEncode("/TakeABreak/ImageDetails?id="),
                    this.Model.Image.Id)));
                return;
            }

            var linkButton = sender as LinkButton;
            if (linkButton != null)
            {
                int imgId = -1;
                if (int.TryParse(linkButton.Attributes["imgId"], out imgId))
                {
                    this.ImageLiked?.Invoke(this, new FormGetItemEventArgs(imgId));
                }
            }
        }

        protected void LinkButtonDislike_Click(object sender, EventArgs e)
        {
            if (!this.User.Identity.IsAuthenticated)
            {
                Response.Redirect(this.ResolveUrl(string.Format(
                    "~/Account/Login?ReturnUrl={0}{1}",
                    HttpUtility.UrlEncode("/TakeABreak/ImageDetails?id="),
                    this.Model.Image.Id)));
                return;
            }

            var linkButton = sender as LinkButton;
            if (linkButton != null)
            {
                int imgId = -1;
                if (int.TryParse(linkButton.Attributes["imgId"], out imgId))
                {
                    this.ImageDisliked?.Invoke(this, new FormGetItemEventArgs(imgId));
                }
            }
        }

        protected void ButtonAddComment_Click(object sender, EventArgs e)
        {
            this.ImageCommented?.Invoke(sender, new ImageCommentEventArgs()
            {
                ImageId = this.Model.Image.Id,
                AuthorId = this.User.Identity.GetUserId(),
                Comment = this.TextBoxComment.Text
            });
            this.TextBoxComment.Text = "";
        }
    }
}