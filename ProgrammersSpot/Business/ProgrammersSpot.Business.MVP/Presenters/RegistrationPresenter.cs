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
        private readonly ILocationService locationService;

        public RegistrationPresenter(
            IRegistrationView view, 
            IRegistrationService registrationService,
            ILocationService locationService)
            : base(view)
        {
            Guard.WhenArgument(registrationService, "registrationService").IsNull().Throw();

            this.registrationService = registrationService;
            this.locationService = locationService;

            this.View.EventRegisterUser += RegisterUser;
            this.View.EventBindPageData += BindPageData;
        }

        private void BindPageData(object sender, EventArgs e)
        {
            this.View.Model.UserRoles = this.registrationService.GetAllUserRoles();
            this.View.Model.Countries = this.locationService.GetAllCountries();
            this.View.Model.Cities = this.locationService.GetAllCities();
        }

        private void RegisterUser(object sender, RegistrationEventArgs e)
        {
            var manager = e.OwinCtx.GetUserManager<ApplicationUserManager>();
            var signInManager = e.OwinCtx.Get<ApplicationSignInManager>();

            var user = new User()
            {
                Email = e.Email,             
                UserName = e.Email,
            };

            IdentityResult result = manager.Create(user, e.Password);

            manager.AddToRoles(user.Id, e.UserType);

            if (e.UserType == "User")
            {
                this.registrationService.CreateRegularUser(user.Id, e.FirstName, e.LastName, e.Email);
            }
            else if (e.UserType == "Firm")
            {
                var country = this.locationService.GetCountryByName(e.Country);
                var city = this.locationService.GetCityByName(e.City);
                this.registrationService.CreateFirm(user.Id, e.FirmName, e.Email, country, city, e.Address);
            }

            signInManager.SignIn(user, isPersistent: false, rememberBrowser: false);
            this.View.Model.Result = result;          
        }
    }
}
