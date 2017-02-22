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

namespace ProgrammersSpot.WebClient.Programmers
{
    [PresenterBinding(typeof(ProgrammerDetailsPresenter))]
    public partial class ProgrammerDetails : MvpPage<ProgrammerDetailsViewModel>, IProgrammerDetailsView
    {
        public event EventHandler<FindUserEventArgs> EventGetProgrammer;
        public event EventHandler<FindUserEventArgs> EventGetLoggedInUser;
        public event EventHandler<StarUserEventArgs> ProgrammerStarred;
        public event EventHandler<StarUserEventArgs> ProgrammerUnstarred;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                string id = Request.QueryString["id"];
                if(id == this.User.Identity.GetUserId())
                {
                    Response.Redirect("~/Account/Profile");
                }
                               
                this.EventGetProgrammer?.Invoke(this, new FindUserEventArgs(id));

                if (this.User.Identity.IsAuthenticated && this.User.IsInRole("User"))
                {
                    this.EventGetLoggedInUser?.Invoke(this, new FindUserEventArgs(this.User.Identity.GetUserId()));

                    if (this.Model.LoggedInUser.StarredUsers.Contains(this.Model.Programmer))
                    {
                        this.Star.Text = "<i class='fa fa-star'></i> Unstar";
                    }
                    else
                    {
                        this.Star.Text = "<i class='fa fa-star'></i> Star";
                    }
                }
                
                this.Skills.DataSource = this.Model.Programmer.Skills;
                this.Skills.DataBind();

                this.Projects.DataSource = this.Model.Programmer.Projects;
                this.Projects.DataBind();

                return;
            }

            Response.StatusCode = 404;
        }

        protected void Star_Click(object sender, EventArgs e)
        {
            if (!this.User.Identity.IsAuthenticated)
            {
                Response.Redirect(this.ResolveUrl(string.Format(
                    "~/Account/Login?ReturnUrl={0}{1}",
                    HttpUtility.UrlEncode("/Programmers/ProgrammerDetails?id="),
                    this.Model.Programmer.Id)));
                return;
            }
            else if (this.User.IsInRole("User"))
            {
                var linkButton = sender as LinkButton;
                if (linkButton != null)
                {
                    if (linkButton.Text == "<i class='fa fa-star'></i> Star")
                    {
                        string userId = linkButton.Attributes["programmerId"];
                        this.ProgrammerStarred?.Invoke(this, new StarUserEventArgs
                        {
                            LoggedUserId = this.User.Identity.GetUserId(),
                            StarredUserId = userId
                        });

                        linkButton.Text = "<i class='fa fa-star'></i> Unstar";
                    }
                    else if (linkButton.Text == "<i class='fa fa-star'></i> Unstar")
                    {
                        string userId = linkButton.Attributes["programmerId"];
                        this.ProgrammerUnstarred?.Invoke(this, new StarUserEventArgs
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