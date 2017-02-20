using ProgrammersSpot.Business.MVP.Args;
using ProgrammersSpot.Business.MVP.ViewModels;
using System;
using WebFormsMvp;

namespace ProgrammersSpot.Business.MVP.Views
{
    public interface IUserProfileView : IView<UserProfileViewModel>
    {
        event EventHandler<FindUserEventArgs> FindRegularUser;

        event EventHandler<FindUserEventArgs> FindFirmUser;
    }
}
