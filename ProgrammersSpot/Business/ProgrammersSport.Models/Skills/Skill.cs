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
        private ICollection<User> users;

        public Skill()
        {
            this.users = new HashSet<User>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [MinLength(Constants.MinSkillLength)]
        [MaxLength(Constants.MaxSkillLength)]
        public string Name { get; set; }

        public bool IsDeleted { get; set; }

        public virtual ICollection<User> Users
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
