using ProgrammersSpot.Business.Common;
using ProgrammersSpot.Business.Models.Users;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProgrammersSpot.Business.Models.Projects
{
    public class Project : IProject
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [MinLength(Constants.NameMinLength)]
        [MaxLength(Constants.NameMaxLength)]
        public string Name { get; set; }

        [Required]
        public string LinkToProject { get; set; }

        public bool IsDeleted { get; set; }

        public string AuthorId { get; set; }

        public virtual RegularUser Author { get; set; }
    }
}
