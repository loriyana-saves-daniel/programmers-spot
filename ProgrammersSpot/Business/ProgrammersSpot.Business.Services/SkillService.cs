using Bytes2you.Validation;
using ProgrammersSpot.Business.Models.Skills;
using ProgrammersSpot.Business.Services.Contracts;

namespace ProgrammersSpot.Business.Services
{
    public class SkillService : ISkillService
    {
        public Skill CreateSkill(string name)
        {
            Guard.WhenArgument(name, "name").IsNullOrEmpty().Throw();

            var skill = new Skill
            {
                Name = name
            };

            return skill;
        }
    }
}
