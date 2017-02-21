using Microsoft.AspNet.Identity.EntityFramework;
using ProgrammersSpot.Business.Data.Contracts;
using ProgrammersSpot.Business.Models.Locations;
using ProgrammersSpot.Business.Models.Projects;
using ProgrammersSpot.Business.Models.Reviews;
using ProgrammersSpot.Business.Models.Skills;
using ProgrammersSpot.Business.Models.UploadedImageComments;
using ProgrammersSpot.Business.Models.UploadedImages;
using ProgrammersSpot.Business.Models.Users;
using System.Data.Entity;

namespace ProgrammersSpot.Business.Data
{
    public class ProgrammersSpotDbContext : IdentityDbContext<User>, IProgrammersSpotDbContext
    {
        public ProgrammersSpotDbContext()
            : base("ProgrammersSpotDb", throwIfV1Schema: false)
        {
        }

        public static ProgrammersSpotDbContext Create()
        {
            return new ProgrammersSpotDbContext();
        }

        IDbSet<T> IProgrammersSpotDbContext.Set<T>()
        {
            return base.Set<T>();
        }

        void IProgrammersSpotDbContext.SaveChanges()
        {
            base.SaveChanges();
        }

        public virtual IDbSet<Review> Reviews { get; set; }

        public virtual IDbSet<Project> Projects { get; set; }

        public virtual IDbSet<UploadedImage> UploadedImages { get; set; }

        public virtual IDbSet<UploadedImageComment> UploadedImageComments { get; set; }

        public virtual IDbSet<Skill> Skills { get; set; }

        public virtual IDbSet<City> Cities { get; set; }

        public virtual IDbSet<Country> Countries { get; set; }

        public virtual IDbSet<RegularUser> RegularUsers { get; set; }

        public virtual IDbSet<FirmUser> Firms { get; set; }

        public virtual IDbSet<Admin> Admins { get; set; }
    }
    
}
