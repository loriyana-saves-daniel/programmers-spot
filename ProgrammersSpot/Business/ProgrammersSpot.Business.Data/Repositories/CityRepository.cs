using ProgrammersSpot.Business.Data.Contracts;
using ProgrammersSpot.Business.Models.Locations;
using System.Linq;

namespace ProgrammersSpot.Business.Data.Repositories
{
    public class CityRepository : GenericRepository<City>, IRepository<City>, ICityRepository
    {
        public CityRepository(IProgrammersSpotDbContext dbContext)
            : base(dbContext)
        {
        }

        public City GetByName(string name)
        {
            return base.DbSet.First(c => c.Name == name);
        }
    }
}
