using ProgrammersSport.Business.Models.Locations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
