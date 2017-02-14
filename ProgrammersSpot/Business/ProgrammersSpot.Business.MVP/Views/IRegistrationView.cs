using ProgrammersSpot.Business.MVP.Args;
using ProgrammersSpot.Business.MVP.ViewModels;
using System;
using WebFormsMvp;

namespace ProgrammersSpot.Business.MVP.Views
{
    public interface IRegistrationView : IView<RegistrationViewModel>
    {
        event EventHandler<RegistrationEventArgs> EventRegisterUser;

        event EventHandler<EventArgs> EventBindPageData;
    }
}
