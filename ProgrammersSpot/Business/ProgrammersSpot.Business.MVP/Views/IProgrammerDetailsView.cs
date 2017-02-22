using ProgrammersSpot.Business.MVP.Args;
using ProgrammersSpot.Business.MVP.ViewModels;
using System;
using WebFormsMvp;

namespace ProgrammersSpot.Business.MVP.Views
{
    public interface IProgrammerDetailsView : IView<ProgrammerDetailsViewModel>
    {
        event EventHandler<FindUserEventArgs> EventGetProgrammer;

        event EventHandler<FindUserEventArgs> EventGetLoggedInUser;

        event EventHandler<StarUserEventArgs> ProgrammerStarred;

        event EventHandler<StarUserEventArgs> ProgrammerUnstarred;
    }
}
