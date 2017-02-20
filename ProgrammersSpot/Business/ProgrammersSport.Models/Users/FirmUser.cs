using ProgrammersSpot.Business.Common;
using ProgrammersSpot.Business.Models.Locations;
using ProgrammersSpot.Business.Models.Reviews;
using ProgrammersSpot.Business.Models.Users.Contracts;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProgrammersSpot.Business.Models.Users
{
    public class FirmUser : IFirmUser
    {
        private ICollection<Review> firmReviews;

        public FirmUser()
        {
            this.firmReviews = new HashSet<Review>();
        }

        [Key, ForeignKey("User")]
        public string Id { get; set; }

        public string FirmName { get; set; }

        public string Email { get; set; }

        public string AvatarUrl { get; set; }

        public virtual User User { get; set; }

        public int CountryId { get; set; }

        public virtual Country Country { get; set; }

        public int CityId { get; set; }

        public virtual City City { get; set; }

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
