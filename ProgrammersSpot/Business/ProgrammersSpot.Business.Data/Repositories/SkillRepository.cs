using ProgrammersSpot.Business.Data.Contracts;
using ProgrammersSpot.Business.Models.Skills;
using System.Linq;

namespace ProgrammersSpot.Business.Data.Repositories
{
    public class SkillRepository : GenericRepository<Skill>, IRepository<Skill>, ISkillRepository
    {
        public SkillRepository(IProgrammersSpotDbContext dbContext)
            : base(dbContext)
        {
        }

        public Skill GetByName(string name)
        {
            return base.DbSet.FirstOrDefault(c => c.Name.ToLower() == name.ToLower());
        }
    }
}
