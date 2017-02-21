using ProgrammersSpot.Business.MVP.Args;
using ProgrammersSpot.Business.MVP.ViewModels;
using System;
using WebFormsMvp;

namespace ProgrammersSpot.Business.MVP.Views
{
    public interface IUploadImageView : IView<UploadImageViewModel>
    {
        event EventHandler<UploadImageEventArgs> EventImageUpload;
    }
}
