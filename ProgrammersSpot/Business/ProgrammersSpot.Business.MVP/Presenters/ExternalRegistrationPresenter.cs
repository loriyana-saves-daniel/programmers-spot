using Bytes2you.Validation;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using ProgrammersSpot.Business.Identity;
using ProgrammersSpot.Business.Models.Users;
using ProgrammersSpot.Business.MVP.Args;
using ProgrammersSpot.Business.MVP.Views;
using ProgrammersSpot.Business.Services.Contracts;
using WebFormsMvp;

namespace ProgrammersSpot.Business.MVP.Presenters
{
    public class ExternalRegistrationPresenter : Presenter<IExternalRegistrationView>
    {
        private readonly IRegistrationService registrationService;

        public ExternalRegistrationPresenter(
            IExternalRegistrationView view, 
            IRegistrationService registrationService) 
            : base(view)
        {
            Guard.WhenArgument(registrationService, "registrationService").IsNull().Throw();

            this.registrationService = registrationService;
            view.EventAddSocialLogin += this.OnAddSocialLogin;
            view.EventExternalRegisterUser += this.OnExternalRegisterUser;
            view.EventGetUserBySocialLogin += this.OnGetUserBySocialLogin;
            view.EventSignIn += this.OnSignIn;
        }

        private void OnSignIn(object sender, OwinCtxEventArgs e)
        {
            e.OwinCtx.Get<ApplicationSignInManager>().SignIn(this.View.Model.User, isPersistent: false, rememberBrowser: false);
        }

        private void OnGetUserBySocialLogin(object sender, SocialLoginEventArgs e)
        {
            this.View.Model.User = e.OwinCtx.GetUserManager<ApplicationUserManager>().Find(e.UserLoginInfo);
        }

        private void OnExternalRegisterUser(object sender, RegistrationEventArgs e)
        {
            var manager = e.OwinCtx.GetUserManager<ApplicationUserManager>();

            var user = new User()
            {
                Email = e.Email,
                UserName = e.Email,
            };

            this.View.Model.User = user;
            this.View.Model.Result = manager.Create(user);

            manager.AddToRoles(user.Id, e.UserType);

            if (e.UserType == "User")
            {
                this.registrationService.CreateRegularUser(user.Id, e.FirstName, e.LastName, e.Email);
            }
        }

        private void OnAddSocialLogin(object sender, SocialLoginEventArgs e)
        {
            this.View.Model.Result = e.OwinCtx.Get<ApplicationUserManager>().AddLogin(e.UserId, e.UserLoginInfo);
        }
    }
}
