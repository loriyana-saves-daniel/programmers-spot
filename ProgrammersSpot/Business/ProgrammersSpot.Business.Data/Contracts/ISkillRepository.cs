using ProgrammersSpot.Business.Models.Skills;

namespace ProgrammersSpot.Business.Data.Contracts
{
    public interface ISkillRepository : IRepository<Skill>
    {
        Skill GetByName(string name);
    }
}
