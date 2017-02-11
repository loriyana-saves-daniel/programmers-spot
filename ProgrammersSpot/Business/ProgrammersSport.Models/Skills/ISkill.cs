using ProgrammersSpot.Business.Models.Users;
using System.Collections.Generic;

namespace ProgrammersSport.Business.Models.Skills
{
    public interface ISkill
    {
        int Id { get; set; }

        string Name { get; set; }

        bool IsDeleted { get; set; }

        ICollection<User> Users { get; set; }
    }
}
