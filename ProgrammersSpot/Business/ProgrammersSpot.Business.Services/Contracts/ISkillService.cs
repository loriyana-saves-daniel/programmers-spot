using ProgrammersSpot.Business.Models.Skills;

namespace ProgrammersSpot.Business.Services.Contracts
{
    public interface ISkillService
    {
        Skill CreateSkill(string name);

        Skill GetSkillByName(string name);
    }
}
