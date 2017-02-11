using System;
using System.ComponentModel.DataAnnotations;
using ProgrammersSpot.Business.Models.Users;

namespace ProgrammersSpot.Business.Models.Projects
{
    public class Project : IProject
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string LinkToProject { get; set; }

        public bool IsDeleted { get; set; }

        public string AuthorId { get; set; }

        public virtual User Author { get; set; }
    }
}
