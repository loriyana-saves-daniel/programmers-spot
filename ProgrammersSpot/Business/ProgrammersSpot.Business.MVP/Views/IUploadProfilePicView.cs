using ProgrammersSpot.Business.MVP.Args;
using ProgrammersSpot.Business.MVP.ViewModels;
using System;
using WebFormsMvp;

namespace ProgrammersSpot.Business.MVP.Views
{
    public interface IUploadProfilePicView : IView<UploadImageViewModel>
    {
        event EventHandler<UploadProfilePicEventArgs> EventImageUpload;
    }
}
