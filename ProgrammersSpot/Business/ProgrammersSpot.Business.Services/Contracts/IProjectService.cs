using ProgrammersSpot.Business.Models.Projects;

namespace ProgrammersSpot.Business.Services.Contracts
{
    public interface IProjectService
    {
        Project CreateProject(string name, string link);
    }
}
