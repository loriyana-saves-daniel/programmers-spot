using ProgrammersSpot.Business.Models.Locations;
using System.Linq;

namespace ProgrammersSpot.Business.Services.Contracts
{
    public interface ILocationService
    {
        IQueryable<Country> GetAllCountries();

        IQueryable<City> GetAllCities();

        Country GetCountryByName(string name);

        City GetCityByName(string name);
    }
}
