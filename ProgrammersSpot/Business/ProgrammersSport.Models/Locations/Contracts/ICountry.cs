using System.Collections.Generic;

namespace ProgrammersSport.Business.Models.Locations.Contracts
{
    public interface ICountry
    {
        int Id { get; set; }

        string Name { get; set; }

        ICollection<City> Cities { get; set; }
    }
}
