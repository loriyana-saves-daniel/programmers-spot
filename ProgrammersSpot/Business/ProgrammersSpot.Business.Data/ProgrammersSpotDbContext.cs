using Microsoft.AspNet.Identity.EntityFramework;
using ProgrammersSport.Business.Models.Skills;
using ProgrammersSport.Business.Models.Users;
using ProgrammersSport.Models.Users;
using ProgrammersSpot.Business.Data.Contracts;
using ProgrammersSpot.Business.Models.Projects;
using ProgrammersSpot.Business.Models.Reviews;
using ProgrammersSpot.Business.Models.Users;
using System;
using System.Data.Entity;

namespace ProgrammersSpot.Business.Data
{
    public class ProgrammersSpotDbContext : IdentityDbContext<User>, IProgrammersSpotDbContext
    {
        public ProgrammersSpotDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
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

        public virtual DbSet<Review> Reviews { get; set; }

        public virtual DbSet<Project> Projects { get; set; }

        public virtual DbSet<Skill> Skills { get; set; }

        public virtual DbSet<RegularUser> RegularUsers { get; set; }

        public virtual DbSet<FirmUser> Firms { get; set; }

        public virtual DbSet<Admin> Admins { get; set; }
    }
    
}
