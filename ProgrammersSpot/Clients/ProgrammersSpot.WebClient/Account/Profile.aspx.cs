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

namespace ProgrammersSpot.WebClient.Account
{
    [PresenterBinding(typeof(UserProfilePresenter))]
    public partial class Profile : MvpPage<UserProfileViewModel>, IUserProfileView
    {
        public event EventHandler<FindUserEventArgs> FindRegularUser;

        public event EventHandler<FindUserEventArgs> FindFirmUser;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.User.Identity.IsAuthenticated)
            {
                Response.Redirect(this.ResolveUrl(string.Format("~/Account/Login?ReturnUrl={0}", HttpUtility.UrlEncode("/Account/Profile"))));
            }

            if (this.User.IsInRole("User"))
            {
                var eventArgs = new FindUserEventArgs(this.User.Identity.GetUserId());
                this.FindRegularUser(this, eventArgs);

                var skills = this.LoginView.FindControl("Skills") as Repeater;

                skills.DataSource = this.Model.FoundRegularUser.Skills;

                skills.DataBind();

                var projects = this.LoginView.FindControl("Projects") as Repeater;

                projects.DataSource = this.Model.FoundRegularUser.Projects;

                projects.DataBind();
            }
            else if (this.User.IsInRole("Firm"))
            {
                var eventArgs = new FindUserEventArgs(this.User.Identity.GetUserId());
                this.FindFirmUser(this, eventArgs);
            }
            
        }

        protected void Edit_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Account/Manage.aspx");
        }
    }
}