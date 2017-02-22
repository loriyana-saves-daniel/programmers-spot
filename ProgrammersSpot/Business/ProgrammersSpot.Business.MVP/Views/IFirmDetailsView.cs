using ProgrammersSpot.Business.MVP.Args;
using ProgrammersSpot.Business.MVP.ViewModels;
using System;
using WebFormsMvp;

namespace ProgrammersSpot.Business.MVP.Views
{
    public interface IFirmDetailsView : IView<FirmDetailsViewModel>
    {
        event EventHandler<FindUserEventArgs> EventGetFirm;

        event EventHandler<FindUserEventArgs> EventGetLoggedInUser;

        event EventHandler<FirmReviewEventArgs> FirmReviewed;

        //event EventHandler<StarProgrammerEventArgs> ProgrammerStarred;

        //event EventHandler<StarProgrammerEventArgs> ProgrammerUnstarred;
    }
}
