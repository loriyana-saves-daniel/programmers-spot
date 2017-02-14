using ProgrammersSport.Business.Models.Users.Contracts;
using ProgrammersSpot.Business.Models.Users.Contracts;
using ProgrammersSpot.Business.Models.Users;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProgrammersSport.Business.Models.Users
{
    public class Admin : IAdmin
    {
        private ICollection<IFirmUser> firmRegistrationRequests;

        public Admin()
        {
            this.firmRegistrationRequests = new List<IFirmUser>();
        }

        [Key, ForeignKey("User")]
        public string Id { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<IFirmUser> FirmRegistrationRequests
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
