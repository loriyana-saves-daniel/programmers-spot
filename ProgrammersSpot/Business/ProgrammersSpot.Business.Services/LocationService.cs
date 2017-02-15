using ProgrammersSpot.Business.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgrammersSport.Business.Models.Locations;
using ProgrammersSpot.Business.Data.Contracts;
using Bytes2you.Validation;

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
        public IEnumerable<City> GetAllCities()
        {
            return this.citiesRepo.All();
        }

        public IEnumerable<Country> GetAllCountries()
        {
            return this.countriesRepo.All();
        }

        public City GetCityById(int id)
        {
            return this.citiesRepo.GetById(id);
        }

        public City GetCityByName(string name)
        {
            return this.citiesRepo.GetByName(name);
        }

        public Country GetCountryById(int id)
        {
            return this.countriesRepo.GetById(id);
        }

        public Country GetCountryByName(string name)
        {
            return this.countriesRepo.GetByName(name);
        }
    }
}
