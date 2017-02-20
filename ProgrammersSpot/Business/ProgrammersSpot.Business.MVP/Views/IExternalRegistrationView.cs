using ProgrammersSpot.Business.MVP.Args;
using ProgrammersSpot.Business.MVP.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;

namespace ProgrammersSpot.Business.MVP.Views
{
    public interface IExternalRegistrationView : IView<ExternalRegistrationViewModel>
    {
        event EventHandler<SocialLoginEventArgs> EventGetUserBySocialLogin;
        event EventHandler<RegistrationEventArgs> EventExternalRegisterUser;
        event EventHandler<SocialLoginEventArgs> EventAddSocialLogin;
        event EventHandler<OwinCtxEventArgs> EventSignIn;
    }
}
