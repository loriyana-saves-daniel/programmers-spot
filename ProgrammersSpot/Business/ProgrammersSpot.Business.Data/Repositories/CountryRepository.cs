using ProgrammersSpot.Business.Data.Contracts;
using ProgrammersSpot.Business.Models.Locations;
using System.Linq;

namespace ProgrammersSpot.Business.Data.Repositories
{
    public class CountryRepository : GenericRepository<Country>, IRepository<Country>, ICountryRepository
    {
        public CountryRepository(IProgrammersSpotDbContext dbContext)
            : base(dbContext)
        {
        }

        public Country GetByName(string name)
        {
            return base.DbSet.First(c => c.Name == name);
        }

    }
}
