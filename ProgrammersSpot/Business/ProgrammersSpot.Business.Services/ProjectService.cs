using Bytes2you.Validation;
using ProgrammersSpot.Business.Models.Projects;
using ProgrammersSpot.Business.Services.Contracts;

namespace ProgrammersSpot.Business.Services
{
    public class ProjectService : IProjectService
    {
        public Project CreateProject(string name, string link)
        {
            Guard.WhenArgument(name, "name").IsNullOrEmpty().Throw();
            Guard.WhenArgument(link, "link").IsNullOrEmpty().Throw();

            var project = new Project
            {
                Name = name,
                LinkToProject = link
            };

            return project;
        }
    }
}
