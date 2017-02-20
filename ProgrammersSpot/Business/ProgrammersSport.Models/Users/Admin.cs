using ProgrammersSpot.Business.Models.Users.Contracts;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProgrammersSpot.Business.Models.Users
{
    public class Admin : IAdmin
    {
        private ICollection<FirmUser> firmRegistrationRequests;

        public Admin()
        {
            this.firmRegistrationRequests = new HashSet<FirmUser>();
        }

        [Key, ForeignKey("User")]
        public string Id { get; set; }

        public string Email { get; set; }

        public string AvatarUrl { get; set; }

        public virtual User User { get; set; }

        public bool IsDeleted { get; set; }

        public virtual ICollection<FirmUser> FirmRegistrationRequests
        {
            get
            {
                return this.firmRegistrationRequests;
            }

            set
            {
                this.firmRegistrationRequests = value;
            }
        }
    }
}
