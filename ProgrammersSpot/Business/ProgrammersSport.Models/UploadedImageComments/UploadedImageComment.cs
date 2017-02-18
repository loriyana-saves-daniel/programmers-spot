using ProgrammersSport.Business.Models.UploadedImages;
using ProgrammersSpot.Business.Common;
using ProgrammersSpot.Business.Models.Users;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProgrammersSport.Business.Models.UploadedImageComments
{
    public class UploadedImageComment : IUploadedImageComment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(Constants.MinCommentLength)]
        [MaxLength(Constants.MaxCommentLength)]
        public string Content { get; set; }

        public bool IsDeleted { get; set; }
        
        public string AuthorId { get; set; }

        public virtual RegularUser Author { get; set; }
        
        public int UploadedImageId { get; set; }

        public virtual UploadedImage UploadedImage { get; set; }
    }
}
