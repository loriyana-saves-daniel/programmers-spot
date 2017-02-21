using ProgrammersSpot.Business.MVP.Args;
using ProgrammersSpot.Business.MVP.ViewModels;
using System;
using WebFormsMvp;

namespace ProgrammersSpot.Business.MVP.Views
{
    public interface IProgrammersView : IView<ProgrammersViewModel>
    {
        event EventHandler<EventArgs> EventGetProgrammers;
        event EventHandler<SearchEventArgs> EventSearchProgrammers;
    }
}
