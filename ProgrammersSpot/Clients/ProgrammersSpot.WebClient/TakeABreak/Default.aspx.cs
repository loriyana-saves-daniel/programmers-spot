using ProgrammersSpot.Business.Models.UploadedImages;
using ProgrammersSpot.Business.MVP.Args;
using ProgrammersSpot.Business.MVP.Presenters;
using ProgrammersSpot.Business.MVP.ViewModels;
using ProgrammersSpot.Business.MVP.Views;
using System;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace ProgrammersSpot.WebClient.TakeABreak
{
    [PresenterBinding(typeof(TakeABreakPresenter))]
    public partial class TakeABreak : MvpPage<TakeABreakViewModel>, ITakeABreakView
    {
        public event EventHandler<EventArgs> EventGetImages;
        public event EventHandler<SearchEventArgs> EventSearchImages;
        public event EventHandler<FormGetItemEventArgs> ImageLiked;
        public event EventHandler<FormGetItemEventArgs> ImageDisliked;

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public IQueryable<UploadedImage> ListViewImages_GetData([Control] string sortBy, [QueryString("imgTitle")] string query)
        {
            if (query == null)
            {
                this.EventGetImages?.Invoke(this, new EventArgs());
            }
            else
            {
                this.EventSearchImages?.Invoke(this, new SearchEventArgs(query));
            }

            var images = this.Model.UploadedImages;
            if (sortBy == "DateUploaded")
            {
                if (this.CheckBoxIsDescending.Checked)
                {
                    images = images.OrderByDescending(i => i.DateUploaded);
                }
                else
                {
                    images = images.OrderBy(i => i.DateUploaded);
                }
            }
            else if (sortBy == "LikesCount")
            {
                if (this.CheckBoxIsDescending.Checked)
                {
                    images = images.OrderByDescending(i => i.LikesCount);
                }
                else
                {
                    images = images.OrderBy(i => i.LikesCount);
                }
            }

            return images;
        }

        protected void LinkButtonSearch_Click(object sender, EventArgs e)
        {
            string queryParam = string.Format("?imgTitle={0}", this.TextBoxSearch.Text);
            Response.Redirect(this.ResolveUrl("~/TakeABreak" + queryParam));
        }

        protected void LinkButtonUploadImage_Click(object sender, EventArgs e)
        {
            if (this.User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/TakeABreak/UserUploadImage");
            }
            else
            {
                Response.Redirect(this.ResolveUrl(string.Format("~/Account/Login?ReturnUrl={0}", HttpUtility.UrlEncode("/TakeABreak/UserUploadImage"))));
            }
        }

        protected void LinkButtonLike_Click(object sender, EventArgs e)
        {
            if (!this.User.Identity.IsAuthenticated)
            {
                Response.Redirect(this.ResolveUrl(string.Format("~/Account/Login?ReturnUrl=", HttpUtility.UrlEncode("/TakeABreak"))));
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
                Response.Redirect(this.ResolveUrl(string.Format("~/Account/Login?ReturnUrl=", HttpUtility.UrlEncode("/TakeABreak"))));
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
    }
}