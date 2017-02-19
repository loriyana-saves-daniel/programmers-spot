using ProgrammersSpot.Business.MVP.Args;
using ProgrammersSpot.Business.MVP.ViewModels;
using System;
using WebFormsMvp;

namespace ProgrammersSpot.Business.MVP.Views
{
    public interface ITakeABreakView : IView<TakeABreakViewModel>
    {
        event EventHandler<EventArgs> EventBindPageData;
        event EventHandler<SearchEventArgs> EventSearchImages;
    }
}
