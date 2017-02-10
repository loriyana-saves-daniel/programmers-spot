using ProgrammersSpot.Business.Models.Users;

namespace ProgrammersSpot.Business.Models.Projects
{
    public interface IProject
    {
        int Id { get; set; }

        bool IsDeleted { get; set; }

        string Description { get; set; }

        string LinkToProject { get; set; }

        string AuthorId { get; set; }

        User Author { get; set; }
    }
}
