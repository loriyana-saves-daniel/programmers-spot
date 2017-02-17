using ProgrammersSpot.Business.Models.Locations;

namespace ProgrammersSpot.Business.Data.Contracts
{
    public interface ICountryRepository : IRepository<Country>
    {
        Country GetByName(string name);
    }
}
