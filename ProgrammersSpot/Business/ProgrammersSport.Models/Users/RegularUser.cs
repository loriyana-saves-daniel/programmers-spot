using ProgrammersSpot.Business.Models.Users;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ProgrammersSpot.Business.Common;
using ProgrammersSpot.Business.Models.Users.Contracts;
using ProgrammersSpot.Business.Models.Reviews;
using ProgrammersSpot.Business.Models.Projects;
using ProgrammersSpot.Business.Models.Skills;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProgrammersSpot.Business.Models.Users
{
    public class RegularUser : IRegularUser
    {
        private ICollection<IReview> reviews;

        private ICollection<IProject> projects;

        private ICollection<ISkill> skills;

        public RegularUser()
        {
            this.reviews = new List<IReview>();
            this.projects = new List<IProject>();
            this.skills = new HashSet<ISkill>();
        }

        [Key, ForeignKey("User")]
        public string Id { get; set; }

        public virtual User User { get; set; }

        [MinLength(Constants.NameMinLength)]
        [MaxLength(Constants.NameMaxLength)]
        public string FirstName { get; set; }

        [MinLength(Constants.NameMinLength)]
        [MaxLength(Constants.NameMaxLength)]
        public string LastName { get; set; }

        public int Age { get; set; }

        public string JobTitle { get; set; }

        public bool IsDeleted { get; set; }

        public virtual ICollection<IProject> Projects
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
        

        public virtual ICollection<IReview> GivenReviews
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

        public virtual ICollection<ISkill> Skills
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
