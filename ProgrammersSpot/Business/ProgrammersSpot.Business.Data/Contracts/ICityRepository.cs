using ProgrammersSport.Business.Models.Locations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersSpot.Business.Data.Contracts
{
    public interface ICityRepository : IRepository<City>
    {
        City GetByName(string name);
    }
}
