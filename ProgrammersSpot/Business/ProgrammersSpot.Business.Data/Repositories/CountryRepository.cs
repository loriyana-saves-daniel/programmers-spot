using ProgrammersSport.Business.Models.Locations;
using ProgrammersSpot.Business.Data.Contracts;
using ProgrammersSpot.Business.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
