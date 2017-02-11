using Bytes2you.Validation;
using System;
using WebFormsMvp;
using WebFormsMvp.Binder;

using ProgramersSpot.Client.Factories.Contracts;

namespace ProgramersSpot.Client.Factories
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