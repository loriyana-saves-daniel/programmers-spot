using ProgrammersSpot.Business.Common;
using ProgrammersSpot.Business.Models.Projects;
using ProgrammersSpot.Business.Models.Reviews;
using ProgrammersSpot.Business.Models.Skills;
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

        public RegularUser()
        {
            this.reviews = new List<Review>();
            this.projects = new List<Project>();
            this.skills = new HashSet<Skill>();
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

        public int Age { get; set; }

        public string JobTitle { get; set; }

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
    }
}
