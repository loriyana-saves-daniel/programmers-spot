using System.Collections.Generic;

namespace ProgrammersSpot.Business.Models.Locations.Contracts
{
    public interface ICountry
    {
        int Id { get; set; }

        string Name { get; set; }

        ICollection<City> Cities { get; set; }
    }
}
