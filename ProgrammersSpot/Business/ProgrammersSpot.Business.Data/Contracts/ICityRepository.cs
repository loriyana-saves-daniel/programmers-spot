using ProgrammersSpot.Business.Models.Locations;

namespace ProgrammersSpot.Business.Data.Contracts
{
    public interface ICityRepository : IRepository<City>
    {
        City GetByName(string name);
    }
}
