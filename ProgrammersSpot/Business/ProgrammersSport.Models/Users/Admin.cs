using ProgrammersSport.Business.Models.Users.Contracts;
using ProgrammersSpot.Business.Models.Users.Contracts;
using ProgrammersSpot.Business.Models.Users;
using System.Collections.Generic;

namespace ProgrammersSport.Business.Models.Users
{
    public class Admin : User, IAdmin
    {
        private ICollection<IFirmUser> firmRegistrationRequests;

        public Admin()
        {
            this.firmRegistrationRequests = new List<IFirmUser>();
        }

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
