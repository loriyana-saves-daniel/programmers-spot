﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using ProgrammersSpot.Business.Identity;
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
    [PresenterBinding(typeof(ManageUserProfilePresenter))]
    public partial class Manage : MvpPage<ManageUserProfileViewModel>, IManageUserProfileView
    {
        protected string SuccessMessage
        {
            get;
            private set;
        }

        public event EventHandler<ManageUserProfileEventArgs> AddSkill;

        public event EventHandler<ManageUserProfileEventArgs> AddProject;

        public event EventHandler<EditUserInfoEventArgs> UpdateUserInfo;

        private bool HasPassword(ApplicationUserManager manager)
        {
            return manager.HasPassword(User.Identity.GetUserId());
        }

        protected void Page_Load()
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();

            var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;

            if (!IsPostBack)
            {
                // Determine the sections to render
                if (HasPassword(manager))
                {
                    ChangePassword.Visible = true;
                }
                else
                {
                    //CreatePassword.Visible = true;
                    ChangePassword.Visible = false;
                }

                // Render success message
                var message = Request.QueryString["m"];
                if (message != null)
                {
                    // Strip the query string from action
                    Form.Action = ResolveUrl("~/Account/ManagePassword");

                    SuccessMessage =
                        message == "ChangePwdSuccess" ? "Your password has been changed."
                        : message == "SetPwdSuccess" ? "Your password has been set."
                        : message == "RemoveLoginSuccess" ? "The account was removed."
                        : message == "AddPhoneNumberSuccess" ? "Phone number has been added"
                        : message == "RemovePhoneNumberSuccess" ? "Phone number was removed"
                        : String.Empty;
                    successMessage.Visible = !String.IsNullOrEmpty(SuccessMessage);
                }
            }
        }

        protected void Update_Click(object sender, EventArgs e)
        {
            var ageTextBox = this.LoginView.FindControl("Age") as TextBox;
            var jobTitleTextBox = this.LoginView.FindControl("JobTitle") as TextBox;
            var facebookTextBox = this.LoginView.FindControl("Facebook") as TextBox;
            var githubTextBox = this.LoginView.FindControl("GitHub") as TextBox;

            var eventArgs = new EditUserInfoEventArgs()
            {
                Age = ageTextBox.Text,
                JobTitle = jobTitleTextBox.Text,
                FacebookProfile = facebookTextBox.Text,
                GitHubProfile = githubTextBox.Text,
                UserId = this.User.Identity.GetUserId()
            };

            this.UpdateUserInfo(this, eventArgs);
            Response.Redirect("Profile");
        }

        protected void AddSkill_Click(object sender, EventArgs e)
        {
            var skillTextBox = this.LoginView.FindControl("Skill") as TextBox;
            var eventArgs = new ManageUserProfileEventArgs()
            {
                SkillName = skillTextBox.Text,
                UserId = this.User.Identity.GetUserId()
            };

            this.AddSkill(this, eventArgs);
            Response.Redirect("Profile");
        }

        protected void AddProject_Click(object sender, EventArgs e)
        {
            var projectNameTextBox = this.LoginView.FindControl("Project") as TextBox;
            var projectLinkTextBox = this.LoginView.FindControl("LinkToProject") as TextBox;

            var eventArgs = new ManageUserProfileEventArgs()
            {
                ProjectName = projectNameTextBox.Text,
                LinkToProject = projectLinkTextBox.Text,
                UserId = this.User.Identity.GetUserId()
            };

            this.AddProject(this, eventArgs);
            Response.Redirect("Profile");
        }
    }
}