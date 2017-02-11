using System;
using WebFormsMvp;

using ProgrammersSpot.Business.MVP.ViewModels;

namespace ProgrammersSpot.Business.MVP.Views
{
    public interface ITestView : IView<TestViewModel>
    {
        event EventHandler MyInit;
    }
}
