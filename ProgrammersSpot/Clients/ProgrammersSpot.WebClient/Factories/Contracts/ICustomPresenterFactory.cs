using System;
using WebFormsMvp;

namespace ProgrammersSpot.WebClient.Factories.Contracts
{
    public interface ICustomPresenterFactory
    {
        IPresenter GetPresenter(Type presenterType, IView viewInstance);
    }
}