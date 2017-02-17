using ProgrammersSpot.Business.Models.Locations;
using System.Collections.Generic;

namespace ProgrammersSpot.Business.Services.Contracts
{
    public interface ILocationService
    {
        IEnumerable<Country> GetAllCountries();

        IEnumerable<City> GetAllCities();

        Country GetCountryById(int id);

        Country GetCountryByName(string name);

        City GetCityById(int id);

        City GetCityByName(string name);
    }
}
