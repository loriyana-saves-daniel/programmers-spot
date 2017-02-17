using ProgrammersSpot.Business.MVP.ViewModels;
using System;
using WebFormsMvp;

namespace ProgrammersSpot.Business.MVP.Views
{
    public interface ITestView : IView<TestViewModel>
    {
        event EventHandler MyInit;
    }
}
