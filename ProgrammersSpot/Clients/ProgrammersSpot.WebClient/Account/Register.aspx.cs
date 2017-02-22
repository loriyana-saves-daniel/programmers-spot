using ProgrammersSpot.Business.Identity;
using ProgrammersSpot.Business.MVP.Args;
using ProgrammersSpot.Business.MVP.Presenters;
using ProgrammersSpot.Business.MVP.ViewModels;
using ProgrammersSpot.Business.MVP.Views;
using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace ProgrammersSpot.WebClient.Account
{
    [PresenterBinding(typeof(RegistrationPresenter))]
    public partial class Register : MvpPage<RegistrationViewModel>, IRegistrationView
    {
        public event EventHandler<RegistrationEventArgs> EventRegisterUser;
        public event EventHandler<EventArgs> EventBindPageData;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.User.Identity.IsAuthenticated)
            {
                this.Response.Redirect("~/");
                this.Response.End();
            }

            if (!Page.IsPostBack)
            {
                this.EventBindPageData(this, e);

                this.UserType.DataSource = this.Model.UserRoles.Where(r => r.Name == "User" || r.Name=="Firm").ToList();
                this.UserType.DataBind();
                this.UserType.SelectedIndex = this.UserType.Items.IndexOf(this.UserType.Items.FindByText("User"));
        
                this.Country.DataSource = this.Model.Countries.ToList();
                this.Country.DataBind();
                this.Country.SelectedIndex = this.Country.Items.IndexOf(this.Country.Items.FindByText("Bulgaria"));

                this.City.DataSource = this.Model.Cities
                .Where(x => x.Country.Name == this.Country.SelectedItem.Text).ToList();
                this.City.DataBind();
                this.City.SelectedIndex = this.City.Items.IndexOf(this.City.Items.FindByText("Sofia"));
            }
        }

        protected void CreateUser_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
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
                        UserType = this.UserType.SelectedItem.Text,
                        Password = this.Password.Text,
                        ConfirmedPassword = this.ConfirmPassword.Text
                    };
                }
                else if (this.UserType.SelectedItem.Text == "Firm")
                {
                    eventArgs = new RegistrationEventArgs()
                    {
                        OwinCtx = owinCtx,
                        Email = this.FirmEmail.Text,
                        FirmName = this.CompanyName.Text,
                        Country = this.Country.SelectedItem.Text,
                        City = this.City.SelectedItem.Text,
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
        }

        protected void UserType_TextChanged(object sender, EventArgs e)
        {
            if (this.UserType.SelectedItem.Text == "User")
            {
                this.RegularUserRegisterForm.Visible = true;
                this.FirmRegisterForm.Visible = false;
            }
            else
            {
                this.RegularUserRegisterForm.Visible = false;
                this.FirmRegisterForm.Visible = true;
            }
        }

        protected void Country_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.EventBindPageData(this, e);
            this.City.DataSource = this.Model.Cities
                .Where(x => x.Country.Name == this.Country.SelectedItem.Text).ToList();
            this.City.DataBind();
        }
    }
}