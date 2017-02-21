using Bytes2you.Validation;
using ProgrammersSpot.Business.Data.Contracts;
using ProgrammersSpot.Business.Models.Locations;
using ProgrammersSpot.Business.Services.Contracts;
using System.Linq;

namespace ProgrammersSpot.Business.Services
{
    public class LocationService : ILocationService
    {
        private readonly ICountryRepository countriesRepo;
        private readonly ICityRepository citiesRepo;
        private readonly IUnitOfWork unitOfWork;

        public LocationService(ICountryRepository countriesRepo, ICityRepository citiesRepo,
            IUnitOfWork unitOfWork)
        {
            Guard.WhenArgument(countriesRepo, "countriesRepo").IsNull().Throw();
            Guard.WhenArgument(citiesRepo, "citiesRepo").IsNull().Throw();
            Guard.WhenArgument(unitOfWork, "unitOfWork").IsNull().Throw();

            this.countriesRepo = countriesRepo;
            this.citiesRepo = citiesRepo;
            this.unitOfWork = unitOfWork;
        }
        public IQueryable<City> GetAllCities()
        {
            return this.citiesRepo.All();
        }

        public IQueryable<Country> GetAllCountries()
        {
            return this.countriesRepo.All();
        }

        public City GetCityByName(string name)
        {
            return this.citiesRepo.GetByName(name);
        }

        public Country GetCountryByName(string name)
        {
            return this.countriesRepo.GetByName(name);
        }
    }
}
