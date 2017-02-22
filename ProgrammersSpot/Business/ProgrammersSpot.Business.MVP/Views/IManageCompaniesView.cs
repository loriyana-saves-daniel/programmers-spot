using ProgrammersSpot.Business.MVP.Args;
using ProgrammersSpot.Business.MVP.ViewModels;
using System;
using WebFormsMvp;

namespace ProgrammersSpot.Business.MVP.Views
{
    public interface IManageCompaniesView : IView<ManageCompaniesViewModel>
    {
        event EventHandler<EventArgs> EventLoadCompanies;

        event EventHandler<UpdateFirmEventArgs> EventUpdateFirm;
    }
}
