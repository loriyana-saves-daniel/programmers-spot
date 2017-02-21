using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using ProgrammersSpot.Business.Identity;
using ProgrammersSpot.Business.MVP.Args;
using ProgrammersSpot.Business.MVP.Presenters;
using ProgrammersSpot.Business.MVP.ViewModels;
using ProgrammersSpot.Business.MVP.Views;
using System;
using System.Web;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace ProgrammersSpot.WebClient.Account
{
    [PresenterBinding(typeof(ExternalRegistrationPresenter))]
    public partial class RegisterExternalLogin : MvpPage<ExternalRegistrationViewModel>, IExternalRegistrationView
    {
        public event EventHandler<SocialLoginEventArgs> EventGetUserBySocialLogin;
        public event EventHandler<RegistrationEventArgs> EventExternalRegisterUser;
        public event EventHandler<SocialLoginEventArgs> EventAddSocialLogin;
        public event EventHandler<OwinCtxEventArgs> EventSignIn;

        protected string ProviderName
        {
            get { return (string)ViewState["ProviderName"] ?? String.Empty; }
            private set { ViewState["ProviderName"] = value; }
        }

        protected string ProviderAccountKey
        {
            get { return (string)ViewState["ProviderAccountKey"] ?? String.Empty; }
            private set { ViewState["ProviderAccountKey"] = value; }
        }

        private void RedirectOnFail()
        {
            this.Response.Redirect((User.Identity.IsAuthenticated) ? "~/Account/Manage" : "~/Account/Login");
        }

        protected void Page_Load()
        {
            // Process the result from an auth provider in the request
            this.ProviderName = IdentityHelper.GetProviderNameFromRequest(Request);
            if (String.IsNullOrEmpty(this.ProviderName))
            {
                this.RedirectOnFail();
                return;
            }

            if (!IsPostBack)
            {
                var loginInfo = Context.GetOwinContext().Authentication.GetExternalLoginInfo();
                if (loginInfo == null)
                {
                    this.RedirectOnFail();
                    return;
                }

                this.EventGetUserBySocialLogin(this, new SocialLoginEventArgs() { OwinCtx = this.Context.GetOwinContext(), UserLoginInfo = loginInfo.Login });

                if (this.Model.User != null)
                {
                    this.EventSignIn(this, new SocialLoginEventArgs() { OwinCtx = this.Context.GetOwinContext() });
                    IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
                }
                else if (this.User.Identity.IsAuthenticated)
                {
                    // Apply Xsrf check when linking
                    var verifiedloginInfo = Context.GetOwinContext().Authentication.GetExternalLoginInfo(IdentityHelper.XsrfKey, this.User.Identity.GetUserId());
                    if (verifiedloginInfo == null)
                    {
                        this.RedirectOnFail();
                        return;
                    }

                    var socialEventArgs = new SocialLoginEventArgs()
                    {
                        OwinCtx = this.Context.GetOwinContext(),
                        UserId = this.User.Identity.GetUserId(),
                        UserLoginInfo = verifiedloginInfo.Login
                    };
                    this.EventAddSocialLogin(this, socialEventArgs);
                    
                    if (this.Model.Result.Succeeded)
                    {
                        IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
                    }
                    else
                    {
                        this.AddErrors(this.Model.Result);
                    }
                }
                else
                {
                    this.Email.Text = loginInfo.Email;
                }
            }
        }        
        
        protected void LogIn_Click(object sender, EventArgs e)
        {
            if (!this.IsValid)
            {
                return;
            }
            
            var eventArgs = new RegistrationEventArgs()
            {
                OwinCtx = this.Context.GetOwinContext(),
                Email = this.Email.Text,
                FirstName = this.FirstName.Text,
                LastName = this.LastName.Text,
                UserType = "User"
            };

            this.EventExternalRegisterUser(this, eventArgs);

            if (this.Model.Result.Succeeded)
            {
                var loginInfo = this.Context.GetOwinContext().Authentication.GetExternalLoginInfo();
                if (loginInfo == null)
                {
                    this.RedirectOnFail();
                    return;
                }

                var socialEventArgs = new SocialLoginEventArgs()
                {
                    OwinCtx = this.Context.GetOwinContext(),
                    UserId = this.Model.User.Id,
                    UserLoginInfo = loginInfo.Login
                };

                this.EventAddSocialLogin(this, socialEventArgs);
                if (this.Model.Result.Succeeded)
                {
                    this.EventSignIn(this, new SocialLoginEventArgs() { OwinCtx = this.Context.GetOwinContext() });

                    IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
                    return;
                }
            }

            this.AddErrors(this.Model.Result);
        }

        private void AddErrors(IdentityResult result) 
        {
            foreach (var error in result.Errors) 
            {
                this.ModelState.AddModelError("", error);
            }
        }
    }
}