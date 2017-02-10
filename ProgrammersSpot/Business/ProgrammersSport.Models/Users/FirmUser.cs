using ProgrammersSpot.Business.Models.Reviews;
using ProgrammersSpot.Business.Models.Users.Contracts;
using ProgrammersSpot.Business.Models.Users;
using System.Collections.Generic;

namespace ProgrammersSport.Business.Models.Users
{
    public class FirmUser : User, IFirmUser
    {
        private ICollection<IReview> firmReviews;

        public FirmUser()
        {
            this.firmReviews = new List<IReview>();
        }
        public string Address { get; set; }

        public int EmployeesCount { get; set; }     

        public int Rating { get; set; }
        
        public string Website { get; set; }

        public bool IsApproved { get; set; }

        public virtual ICollection<IReview> FirmReviews
        {
            get
            {
                return this.firmReviews;
            }
            set
            {
                this.firmReviews = value;
            }
        }

    }
}
