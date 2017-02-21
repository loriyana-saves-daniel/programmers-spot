using Ninject.Extensions.Conventions;
using Ninject.Modules;
using Ninject.Web.Common;
using ProgrammersSpot.Business.Data;
using ProgrammersSpot.Business.Data.Contracts;
using ProgrammersSpot.Business.Data.Repositories;
using ProgrammersSpot.Business.Data.UnitOfWork;

namespace ProgrammersSpot.WebClient.App_Start.NinjectModules
{
    public class DataModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind(x => x.From("ProgrammersSpot.Business.Models").SelectAllClasses().BindDefaultInterface());
            this.Bind(typeof(IRepository<>)).To(typeof(GenericRepository<>));
            this.Bind(typeof(ICountryRepository)).To(typeof(CountryRepository));
            this.Bind(typeof(ICityRepository)).To(typeof(CityRepository));
            this.Bind(typeof(ISkillRepository)).To(typeof(SkillRepository));
            this.Bind<IProgrammersSpotDbContext>().To<ProgrammersSpotDbContext>().InRequestScope();
            this.Bind<IUnitOfWork>().To<UnitOfWork>();
        }
    }
}