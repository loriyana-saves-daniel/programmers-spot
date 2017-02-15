using ProgrammersSpot.Business.Models.Reviews;
using ProgrammersSpot.Business.Models.Users.Contracts;
using ProgrammersSpot.Business.Models.Users;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ProgrammersSpot.Business.Common;

namespace ProgrammersSpot.Business.Models.Users
{
    public class FirmUser : IFirmUser
    {
        private ICollection<Review> firmReviews;

        public FirmUser()
        {
            this.firmReviews = new List<Review>();
        }

        [Key, ForeignKey("User")]
        public string Id { get; set; }

        public virtual User User { get; set; }

        [Required]
        [MinLength(Constants.MinAddressLength)]
        [MaxLength(Constants.MaxAddressLength)]
        public string Address { get; set; }

        public int EmployeesCount { get; set; }     

        public int Rating { get; set; }
        
        public string Website { get; set; }

        public bool IsApproved { get; set; }

        public bool IsDeleted { get; set; }

        public virtual ICollection<Review> FirmReviews
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
