using ProgrammersSpot.Business.Common;
using ProgrammersSpot.Business.Models.Projects;
using ProgrammersSpot.Business.Models.Reviews;
using ProgrammersSpot.Business.Models.Skills;
using ProgrammersSpot.Business.Models.UploadedImages;
using ProgrammersSpot.Business.Models.Users.Contracts;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProgrammersSpot.Business.Models.Users
{
    public class RegularUser : IRegularUser
    {
        private ICollection<Review> reviews;

        private ICollection<Project> projects;

        private ICollection<Skill> skills;

        private ICollection<UploadedImage> uploadedImages;

        private ICollection<RegularUser> starredUsers;

        private ICollection<FirmUser> starredFirms;

        public RegularUser()
        {
            this.reviews = new HashSet<Review>();
            this.projects = new HashSet<Project>();
            this.skills = new HashSet<Skill>();
            this.uploadedImages = new HashSet<UploadedImage>();
            this.starredUsers = new HashSet<RegularUser>();
            this.starredFirms = new HashSet<FirmUser>();
        }

        [Key, ForeignKey("User")]
        public string Id { get; set; }

        public virtual User User { get; set; }

        [Required]
        [MinLength(Constants.NameMinLength)]
        [MaxLength(Constants.NameMaxLength)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(Constants.NameMinLength)]
        [MaxLength(Constants.NameMaxLength)]
        public string LastName { get; set; }

        public string Email { get; set; }

        public string AvatarUrl { get; set; }

        public string GitHubProfile { get; set; }

        public string FacebookProfile { get; set; }

        public int Age { get; set; }

        public string JobTitle { get; set; }

        public int StarsCount { get; set; }

        public bool IsDeleted { get; set; }

        public virtual ICollection<Project> Projects
        {
            get
            {
                return this.projects;
            }
            set
            {
                this.projects = value;
            }
        }

        public virtual ICollection<Review> GivenReviews
        {
            get
            {
                return this.reviews;
            }
            set
            {
                this.reviews = value;
            }
        }

        public virtual ICollection<Skill> Skills
        {
            get
            {
                return this.skills;
            }
            set
            {
                this.skills = value;
            }
        }

        public virtual ICollection<UploadedImage> UploadedImages
        {
            get
            {
                return this.uploadedImages;
            }
            set
            {
                this.uploadedImages = value;
            }
        }

        public virtual ICollection<RegularUser> StarredUsers
        {
            get
            {
                return this.starredUsers;
            }
            set
            {
                this.starredUsers = value;
            }
        }

        public virtual ICollection<FirmUser> StarredFirms
        {
            get
            {
                return this.starredFirms;
            }
            set
            {
                this.starredFirms = value;
            }
        }
    }
}
