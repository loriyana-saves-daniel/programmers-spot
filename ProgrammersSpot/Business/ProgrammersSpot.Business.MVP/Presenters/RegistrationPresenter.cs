using Bytes2you.Validation;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using ProgrammersSpot.Business.Identity;
using ProgrammersSpot.Business.Models.Users;
using ProgrammersSpot.Business.MVP.Args;
using ProgrammersSpot.Business.MVP.Views;
using ProgrammersSpot.Business.Services.Contracts;
using System;
using WebFormsMvp;

namespace ProgrammersSpot.Business.MVP.Presenters
{
    public class RegistrationPresenter : Presenter<IRegistrationView>
    {
        private readonly IRegistrationService registrationService;

        public RegistrationPresenter(IRegistrationView view, IRegistrationService registrationService)
            : base(view)
        {
            Guard.WhenArgument(registrationService, "registrationService").IsNull().Throw();

            this.registrationService = registrationService;

            this.View.EventRegisterUser += RegisterUser;
            this.View.EventBindPageData += BindPageData;
        }

        private void BindPageData(object sender, EventArgs e)
        {
            this.View.Model.UserRoles = this.registrationService.GetAllUserRoles();
        }

        private void RegisterUser(object sender, RegistrationEventArgs e)
        {
            var manager = e.OwinCtx.GetUserManager<ApplicationUserManager>();
            var signInManager = e.OwinCtx.Get<ApplicationSignInManager>();

            var user = new User()
            {
                Email = e.Email,             
                UserName = e.UserName,
            };

            IdentityResult result = manager.Create(user, e.Password);

            manager.AddToRoles(user.Id, e.UserType);

            if (e.UserType == "User")
            {
                this.registrationService.CreateRegularUser(user.Id, e.FirstName, e.LastName);
            }
            else if (e.UserType == "Firm")
            {
                this.registrationService.CreateFirm(user.Id, e.Address);
            }

            signInManager.SignIn(user, isPersistent: false, rememberBrowser: false);
            this.View.Model.Result = result;          
        }
    }
}
