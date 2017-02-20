using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using WebFormsMvp;
using ProgrammersSpot.Business.MVP.Presenters;
using WebFormsMvp.Web;
using ProgrammersSpot.Business.MVP.ViewModels;
using ProgrammersSpot.Business.MVP.Views;
using ProgrammersSpot.Business.MVP.Args;

namespace ProgrammersSpot.WebClient.Account
{
    [PresenterBinding(typeof(UserProfilePresenter))]
    public partial class Profile : MvpPage<UserProfileViewModel>, IUserProfileView
    {
        public event EventHandler<FindUserEventArgs> FindRegularUser;

        public event EventHandler<FindUserEventArgs> FindFirmUser;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (this.User.IsInRole("User"))
                {
                    var eventArgs = new FindUserEventArgs(this.User.Identity.GetUserId());
                    this.FindRegularUser(this, eventArgs);

                    if (string.IsNullOrEmpty(this.Model.FoundRegularUser.AvatarUrl))
                    {
                        this.Model.ProfileImage = "../Content/Images/profile.png";
                    }
                    else
                    {
                        this.Model.ProfileImage = this.Model.FoundRegularUser.AvatarUrl;
                    }

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

                    if (string.IsNullOrEmpty(this.Model.FoundFirmUser.AvatarUrl))
                    {
                        this.Model.ProfileImage = "../Content/Images/firm.png";
                    }
                    else
                    {
                        this.Model.ProfileImage = this.Model.FoundFirmUser.AvatarUrl;
                    }
                }
            }
        }

        protected void Edit_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Account/Manage.aspx");
        }
    }
}