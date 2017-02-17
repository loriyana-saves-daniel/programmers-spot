namespace ProgrammersSpot.Business.Models.Locations.Contracts
{
    public interface ICity
    {
        int Id { get; set; }

        string Name { get; set; }

        int? CountryId { get; set; }

        Country Country { get; set; }
    }
}
