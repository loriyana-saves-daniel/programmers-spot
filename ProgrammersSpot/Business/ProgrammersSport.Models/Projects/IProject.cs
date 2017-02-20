using ProgrammersSpot.Business.Models.Users;

namespace ProgrammersSpot.Business.Models.Projects
{
    public interface IProject
    {
        int Id { get; set; }

        string Name { get; set; }

        bool IsDeleted { get; set; }

        string LinkToProject { get; set; }

        string AuthorId { get; set; }

        RegularUser Author { get; set; }
    }
}
