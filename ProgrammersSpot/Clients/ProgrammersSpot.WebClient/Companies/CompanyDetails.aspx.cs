using Microsoft.AspNet.Identity;
using ProgrammersSpot.Business.MVP.Args;
using ProgrammersSpot.Business.MVP.Presenters;
using ProgrammersSpot.Business.MVP.ViewModels;
using ProgrammersSpot.Business.MVP.Views;
using System;
using System.Web;
using System.Web.UI.WebControls;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace ProgrammersSpot.WebClient.Companies
{
    [PresenterBinding(typeof(FirmDetailsPresenter))]
    public partial class CompanyDetails : MvpPage<FirmDetailsViewModel>, IFirmDetailsView
    {
        public event EventHandler<FindUserEventArgs> EventGetFirm;
        public event EventHandler<FindUserEventArgs> EventGetLoggedInUser;
        public event EventHandler<FirmReviewEventArgs> FirmReviewed;
        public event EventHandler<StarUserEventArgs> FirmStarred;
        public event EventHandler<StarUserEventArgs> FirmUnstarred;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                string id = Request.QueryString["id"];
                if (id == this.User.Identity.GetUserId())
                {
                    Response.Redirect("~/Account/Profile");
                }

                this.EventGetFirm?.Invoke(this, new FindUserEventArgs(id));

                if (this.User.Identity.IsAuthenticated && this.User.IsInRole("User"))
                {
                    this.EventGetLoggedInUser?.Invoke(this, new FindUserEventArgs(this.User.Identity.GetUserId()));

                    if (this.Model.LoggedInUser.StarredFirms.Contains(this.Model.Firm))
                    {
                        this.Star.Text = "<i class='fa fa-star'></i> Unstar";
                    }
                    else
                    {
                        this.Star.Text = "<i class='fa fa-star'></i> Star";
                    }
                }

                return;
            }

            Response.StatusCode = 404;
        }

        protected void ButtonAddReview_Click(object sender, EventArgs e)
        {
            if (this.User.IsInRole("User"))
            {
                this.FirmReviewed?.Invoke(sender, new FirmReviewEventArgs()
                {
                    FirmId = this.Model.Firm.Id,
                    AuthorId = this.User.Identity.GetUserId(),
                    Review = this.TextBoxComment.Text
                });              
            }
            this.TextBoxComment.Text = "";
        }

        protected void Star_Click(object sender, EventArgs e)
        {
            if (!this.User.Identity.IsAuthenticated)
            {
                Response.Redirect(this.ResolveUrl(string.Format(
                    "~/Account/Login?ReturnUrl={0}{1}",
                    HttpUtility.UrlEncode("/Companies/CompanyDetails?id="),
                    this.Model.Firm.Id)));
                return;
            }
            else if (this.User.IsInRole("User"))
            {
                var linkButton = sender as LinkButton;
                if (linkButton != null)
                {
                    if (linkButton.Text == "<i class='fa fa-star'></i> Star")
                    {
                        string userId = linkButton.Attributes["firmId"];
                        this.FirmStarred?.Invoke(this, new StarUserEventArgs
                        {
                            LoggedUserId = this.User.Identity.GetUserId(),
                            StarredUserId = userId
                        });

                        linkButton.Text = "<i class='fa fa-star'></i> Unstar";
                    }
                    else if (linkButton.Text == "<i class='fa fa-star'></i> Unstar")
                    {
                        string userId = linkButton.Attributes["firmId"];
                        this.FirmUnstarred?.Invoke(this, new StarUserEventArgs
                        {
                            LoggedUserId = this.User.Identity.GetUserId(),
                            StarredUserId = userId
                        });

                        linkButton.Text = "<i class='fa fa-star'></i> Star";
                    }
                }
            }
        }
    }
}