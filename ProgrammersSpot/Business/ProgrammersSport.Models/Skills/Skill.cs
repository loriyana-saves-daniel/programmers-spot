using ProgrammersSpot.Business.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ProgrammersSpot.Business.Models.Users;
using System;
using System.Collections.Generic;

namespace ProgrammersSpot.Business.Models.Skills
{
    public class Skill : ISkill
    {
        private ICollection<RegularUser> users;

        public Skill()
        {
            this.users = new HashSet<RegularUser>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [MinLength(Constants.MinSkillLength)]
        [MaxLength(Constants.MaxSkillLength)]
        public string Name { get; set; }

        public bool IsDeleted { get; set; }

        public virtual ICollection<RegularUser> Users
        {
            get
            {
                return this.users;
            }

            set
            {
                this.users = value;
            }
        }
    }
}
