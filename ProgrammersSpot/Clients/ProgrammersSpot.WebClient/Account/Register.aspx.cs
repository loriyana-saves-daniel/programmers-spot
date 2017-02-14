using System;
using System.Linq;
using System.Web;
using System.Web.UI;
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