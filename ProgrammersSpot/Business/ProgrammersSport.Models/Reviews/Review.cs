using ProgrammersSpot.Business.Common;
using ProgrammersSpot.Business.Models.Users;
using System.ComponentModel.DataAnnotations;

namespace ProgrammersSpot.Business.Models.Reviews
{
    public class Review : IReview
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(Constants.MinReviewLength)]
        [MaxLength(Constants.MaxReviewLength)]
        public string Content { get; set; }

        public bool IsDeleted { get; set; }

        public string AuthorId { get; set; }

        public virtual RegularUser Author { get; set; }

        public string FirmId { get; set; }

        public virtual FirmUser Firm { get; set; }
    }
}

