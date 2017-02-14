using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using ProgrammersSpot.Business.Models.Users;
using ProgrammersSport.Models.Users;
using ProgrammersSpot.Business.Identity;
using WebFormsMvp.Web;
using ProgrammersSpot.Business.MVP.Views;
using ProgrammersSpot.Business.MVP.ViewModels;
using ProgrammersSpot.Business.MVP.Args;
using WebFormsMvp;
using ProgrammersSpot.Business.MVP.Presenters;

namespace ProgrammersSpot.WebClient.Account
{
    [PresenterBinding(typeof(RegistrationPresenter))]
    public partial class Register : MvpPage<RegistrationViewModel>, IRegistrationView
    {
        public event EventHandler<RegistrationEventArgs> EventRegisterUser;
        public event EventHandler<EventArgs> EventBindPageData;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.EventBindPageData(this, e);
                this.UserType.DataSource = this.Model.UserRoles.Where(r => r.Name == "User" || r.Name=="Firm").ToList();
                this.UserType.DataBind();

                this.UserType.SelectedIndex = 0;

                if (this.UserType.SelectedItem.Text != "User")
                {
                    this.RegularUserRegisterForm.Visible = false;
                    this.FirmRegisterForm.Visible = true;
                }
                else
                {
                    this.RegularUserRegisterForm.Visible = true;
                    this.FirmRegisterForm.Visible = false;
                }
            }
        }

        protected void CreateUser_Click(object sender, EventArgs e)
        {
            var owinCtx = Context.GetOwinContext();
            var selectedRole = this.UserType.SelectedItem.Value;

            var eventArgs = new RegistrationEventArgs();
            if (this.UserType.SelectedItem.Text == "User")
            {
                eventArgs = new RegistrationEventArgs()
                {
                    OwinCtx = owinCtx,
                    Email = this.Email.Text,
                    FirstName = this.FirstName.Text,
                    LastName = this.LastName.Text,
                    UserName = this.Username.Text,
                    UserType = this.UserType.SelectedItem.Text,
                    Password = this.Password.Text,
                    ConfirmedPassword = this.ConfirmPassword.Text
                };
            }
            else if(this.UserType.SelectedItem.Text == "Firm")
            {
                eventArgs = new RegistrationEventArgs()
                {
                    OwinCtx = owinCtx,
                    Email = this.FirmEmail.Text,
                    UserName = this.CompanyName.Text,
                    Address = this.Address.Text,
                    UserType = this.UserType.SelectedItem.Text,
                    Password = this.FirmPassword.Text,
                    ConfirmedPassword = this.FirmConfirmPassword.Text
                };
            }
            
            EventRegisterUser(this, eventArgs);

            var result = this.Model.Result;

            if (result.Succeeded)
            {
                IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
            }
            else
            {
                ErrorMessage.Text = result.Errors.FirstOrDefault();
            }
        }



        //protected void CreateUser_Click(object sender, EventArgs e)
        //{
        //    var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
        //    var roleManager = Context.GetOwinContext().Get<ApplicationRoleManager>();
        //    var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();

        //    var user = new User();
        //    var regUser = new RegularUser();


        //    switch (UserType.SelectedItem.Value)
        //    {
        //        case "User":
        //            user = new User() { UserName = Username.Text, Email = Email.Text };
        //            regUser = new RegularUser() { FirstName = FirstName.Text, LastName = LastName.Text };
                    
        //            break;
        //        case "Firm":
        //            user = new User() { UserName = CompanyName.Text, Email = Email.Text };
        //            break;
        //        default:
        //            break;
        //    }
        //    IdentityResult result = manager.Create(user, Password.Text);
        //    if (result.Succeeded)
        //    {
        //        // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
        //        //string code = manager.GenerateEmailConfirmationToken(user.Id);
        //        //string callbackUrl = IdentityHelper.GetUserConfirmationRedirectUrl(code, user.Id, Request);
        //        //manager.SendEmail(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>.");

        //        manager.AddToRoles(user.Id, UserType.SelectedItem.Value);

        //        signInManager.SignIn( user, isPersistent: false, rememberBrowser: false);
        //        IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
        //    }
        //    else 
        //    {
        //        ErrorMessage.Text = result.Errors.FirstOrDefault();
        //    }
        //}

        //protected void UserType_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (this.UserType.SelectedItem.Text != "User")
        //    {
        //        this.RegularUserRegisterForm.Visible = false;
        //        this.FirmRegisterForm.Visible = true;
        //    }
        //    else
        //    {
        //        this.RegularUserRegisterForm.Visible = true;
        //        this.FirmRegisterForm.Visible = false;
        //    }
        //}

        protected void UserType_TextChanged(object sender, EventArgs e)
        {
            if (this.UserType.SelectedItem.Text != "User")
            {
                this.RegularUserRegisterForm.Visible = false;
                this.FirmRegisterForm.Visible = true;
            }
            else
            {
                this.RegularUserRegisterForm.Visible = true;
                this.FirmRegisterForm.Visible = false;
            }
        }
    }
}