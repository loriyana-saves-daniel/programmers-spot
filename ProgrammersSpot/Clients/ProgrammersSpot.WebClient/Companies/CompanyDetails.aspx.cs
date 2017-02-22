using Microsoft.AspNet.Identity;
using ProgrammersSpot.Business.MVP.Args;
using ProgrammersSpot.Business.MVP.Presenters;
using ProgrammersSpot.Business.MVP.ViewModels;
using ProgrammersSpot.Business.MVP.Views;
using System;
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
        //public event EventHandler<StarProgrammerEventArgs> ProgrammerStarred;
        //public event EventHandler<StarProgrammerEventArgs> ProgrammerUnstarred;

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

                if (this.User.Identity.IsAuthenticated)
                {
                    this.EventGetLoggedInUser?.Invoke(this, new FindUserEventArgs(this.User.Identity.GetUserId()));

                    //if (this.Model.LoggedInUser.StarredUsers.Contains(this.Model.Programmer))
                    //{
                    //    this.Star.Text = "<i class='fa fa-star'></i> Unstar";
                    //}
                    //else
                    //{
                    //    this.Star.Text = "<i class='fa fa-star'></i> Star";
                    //}
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
                this.TextBoxComment.Text = "";
            }          
        }
    }
}