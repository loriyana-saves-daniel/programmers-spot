using ProgrammersSpot.Business.MVP.Args;
using ProgrammersSpot.Business.MVP.ViewModels;
using System;
using WebFormsMvp;

namespace ProgrammersSpot.Business.MVP.Views
{
    public interface IUserView : IView<UserViewModel>
    {
        event EventHandler<FindRegularUserEventArgs> FindRegularUser;
    }
}
