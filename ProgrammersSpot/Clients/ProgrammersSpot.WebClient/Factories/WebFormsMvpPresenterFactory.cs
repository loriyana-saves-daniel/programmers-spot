using Bytes2you.Validation;
using ProgrammersSpot.WebClient.Factories.Contracts;
using System;
using WebFormsMvp;
using WebFormsMvp.Binder;

namespace ProgrammersSpot.WebClient.Factories
{
    public class WebFormsMvpPresenterFactory : IPresenterFactory
    {
        private readonly ICustomPresenterFactory factory;

        public WebFormsMvpPresenterFactory(ICustomPresenterFactory factory)
        {
            Guard.WhenArgument(factory, "ICustomPresenterFactory").IsNull().Throw();

            this.factory = factory;
        }

        public IPresenter Create(Type presenterType, Type viewType, IView viewInstance)
        {
            return this.factory.GetPresenter(presenterType, viewInstance);
        }

        public void Release(IPresenter presenter)
        {
            var disposable = presenter as IDisposable;
            if (disposable != null)
            {
                disposable.Dispose();
            }
        }
    }
}