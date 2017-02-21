using ProgrammersSpot.Business.MVP.Args;
using ProgrammersSpot.Business.MVP.ViewModels;
using System;
using WebFormsMvp;

namespace ProgrammersSpot.Business.MVP.Views
{
    public interface IFirmsView : IView<FirmsViewModel>
    {
        event EventHandler<EventArgs> EventGetFirms;
        event EventHandler<SearchEventArgs> EventSearchFirms;
    }
}
