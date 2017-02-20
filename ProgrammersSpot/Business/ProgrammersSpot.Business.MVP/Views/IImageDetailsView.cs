using ProgrammersSpot.Business.MVP.Args;
using ProgrammersSpot.Business.MVP.ViewModels;
using System;
using WebFormsMvp;

namespace ProgrammersSpot.Business.MVP.Views
{
    public interface IImageDetailsView : IView<ImageDetailsViewModel>
    {
        event EventHandler<FormGetItemEventArgs> EventGetImage;

        event EventHandler<FormGetItemEventArgs> ImageLiked;

        event EventHandler<FormGetItemEventArgs> ImageDisliked;

        event EventHandler<ImageCommentEventArgs> ImageCommented;
    }
}
