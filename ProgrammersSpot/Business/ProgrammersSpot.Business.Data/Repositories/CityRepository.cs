using ProgrammersSport.Business.Models.Locations;
using ProgrammersSpot.Business.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
