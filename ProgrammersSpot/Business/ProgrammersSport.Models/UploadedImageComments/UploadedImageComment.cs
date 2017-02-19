using ProgrammersSport.Business.Models.UploadedImages;
using ProgrammersSpot.Business.Common;
using ProgrammersSpot.Business.Models.Users;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProgrammersSport.Business.Models.UploadedImageComments
{
    public class UploadedImageComment : IUploadedImageComment
    {
        public UploadedImageComment()
        {
            this.DateCreated = DateTime.Now;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(Constants.MinCommentLength)]
        [MaxLength(Constants.MaxCommentLength)]
        public string Content { get; set; }

        public DateTime DateCreated { get; set; }

        public bool IsDeleted { get; set; }
        
        public string AuthorId { get; set; }

        public virtual RegularUser Author { get; set; }
        
        public int UploadedImageId { get; set; }

        public virtual UploadedImage UploadedImage { get; set; }
    }
}
