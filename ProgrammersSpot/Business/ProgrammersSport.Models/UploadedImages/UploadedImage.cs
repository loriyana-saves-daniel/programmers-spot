using ProgrammersSpot.Business.Common;
using ProgrammersSpot.Business.Models.UploadedImageComments;
using ProgrammersSpot.Business.Models.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProgrammersSpot.Business.Models.UploadedImages
{
    public class UploadedImage : IUploadedImage
    {
        private ICollection<UploadedImageComment> comments;

        public UploadedImage()
        {
            this.comments = new HashSet<UploadedImageComment>();
            this.DateUploaded = DateTime.Now;
        }

        [Key]
        public int Id { get; set; }
        
        [MaxLength(Constants.MaxUploadedImageTitleLength)]
        public string Title { get; set; }
        
        public DateTime DateUploaded { get; set; }

        [Required]
        public string ThumbnailSrc { get; set; }

        [Required]
        public string OriginalSrc { get; set; }

        public bool IsDeleted { get; set; }
        
        public string UploaderId { get; set; }
        
        public virtual RegularUser Uploader { get; set; }

        public virtual ICollection<UploadedImageComment> Comments
        {
            get
            {
                return this.comments;
            }
            set
            {
                this.comments = value;
            }
        }
        
        public int LikesCount { get; set; }

        public int DislikesCount { get; set; }
    }
}
