using System;
using WebFormsMvp;

namespace ProgramersSpot.Client.Factories.Contracts
{
    public interface ICustomPresenterFactory
    {
        IPresenter GetPresenter(Type presenterType, IView viewInstance);
    }
}