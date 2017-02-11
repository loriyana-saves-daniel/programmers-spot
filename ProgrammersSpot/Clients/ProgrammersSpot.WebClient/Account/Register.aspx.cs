using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using ProgrammersSpot.Business.Models.Users;
using ProgrammersSport.Models.Users;
using ProgrammersSport.Business.Models.Users;

namespace ProgrammersSpot.WebClient.Account
{
    public partial class Register : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                var roles = new[]
                {
                    "User",
                    "Firm"
                };

                this.UserType.DataSource = roles;
                this.UserType.DataBind();
                this.UserType.SelectedIndex = 0;
            }
        }
        protected void CreateUser_Click(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var roleManager = Context.GetOwinContext().Get<ApplicationRoleManager>();
            var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();

            var user = new User();

            switch (UserType.SelectedItem.Value)
            {
                case "User":
                    user = new RegularUser() { UserName = Email.Text, Email = Email.Text, Age = 20 };
                    break;
                case "Firm":
                    user = new FirmUser() { UserName = Email.Text, Email = Email.Text, Address = "Al.Malinov"};
                    break;
                default:
                    break;
            }
            IdentityResult result = manager.Create(user, Password.Text);
            if (result.Succeeded)
            {
                // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                //string code = manager.GenerateEmailConfirmationToken(user.Id);
                //string callbackUrl = IdentityHelper.GetUserConfirmationRedirectUrl(code, user.Id, Request);
                //manager.SendEmail(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>.");

                manager.AddToRoles(user.Id, UserType.SelectedItem.Value);

                signInManager.SignIn( user, isPersistent: false, rememberBrowser: false);
                IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
            }
            else 
            {
                ErrorMessage.Text = result.Errors.FirstOrDefault();
            }
        }
    }
}