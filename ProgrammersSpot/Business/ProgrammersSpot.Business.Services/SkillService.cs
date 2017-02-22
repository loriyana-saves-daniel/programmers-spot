using Bytes2you.Validation;
using ProgrammersSpot.Business.Data.Contracts;
using ProgrammersSpot.Business.Models.Skills;
using ProgrammersSpot.Business.Services.Contracts;

namespace ProgrammersSpot.Business.Services
{
    public class SkillService : ISkillService
    {
        private readonly ISkillRepository skillsRepo;

        public SkillService(ISkillRepository skillsRepo)
        {
            Guard.WhenArgument(skillsRepo, "skillsRepo").IsNull().Throw();

            this.skillsRepo = skillsRepo;
        }

        public Skill GetSkillByName(string name)
        {
            return this.skillsRepo.GetByName(name);
        }

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
