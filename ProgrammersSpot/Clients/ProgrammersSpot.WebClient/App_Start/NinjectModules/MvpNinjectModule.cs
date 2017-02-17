using Ninject;
using Ninject.Activation;
using Ninject.Extensions.Factory;
using Ninject.Modules;
using Ninject.Parameters;
using ProgrammersSpot.WebClient.Factories;
using ProgrammersSpot.WebClient.Factories.Contracts;
using System;
using System.Linq;
using WebFormsMvp;
using WebFormsMvp.Binder;

namespace ProgrammersSpot.WebClient.App_Start.NinjectModules
{
    public class MvpNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IPresenterFactory>().To<WebFormsMvpPresenterFactory>().InSingletonScope();

            this.Bind<ICustomPresenterFactory>().ToFactory().InSingletonScope();

            this.Bind<IPresenter>()
                .ToMethod(this.GetPresenter)
                .NamedLikeFactoryMethod((ICustomPresenterFactory factory) => factory.GetPresenter(null, null));
        }

        private IPresenter GetPresenter(IContext context)
        {
            var parameters = context.Parameters.ToList();

            var presenterType = (Type)parameters[0].GetValue(context, null);
            var viewInstance = (IView)parameters[1].GetValue(context, null);

            var constructorParam = new ConstructorArgument("view", viewInstance);

            return (IPresenter)context.Kernel.Get(presenterType, constructorParam);
        }
    }
}