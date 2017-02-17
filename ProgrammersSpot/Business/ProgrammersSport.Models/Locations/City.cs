using ProgrammersSpot.Business.Common;
using ProgrammersSpot.Business.Models.Locations.Contracts;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProgrammersSpot.Business.Models.Locations
{
    public class City : ICity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [MinLength(Constants.NameMinLength)]
        [MaxLength(Constants.NameMaxLength)]
        public string Name { get; set; }

        public int? CountryId { get; set; }

        public virtual Country Country { get; set; }       
    }
}
