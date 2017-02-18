using ProgrammersSpot.Business.Models.Locations;
using System.Collections.Generic;

namespace ProgrammersSpot.Business.Services.Contracts
{
    public interface ILocationService
    {
        IEnumerable<Country> GetAllCountries();

        IEnumerable<City> GetAllCities();

        Country GetCountryByName(string name);

        City GetCityByName(string name);
    }
}
