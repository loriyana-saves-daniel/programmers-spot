using ProgrammersSpot.Business.Models.Projects;
using ProgrammersSpot.Business.Models.Reviews;
using ProgrammersSpot.Business.Models.Skills;
using System.Collections.Generic;

namespace ProgrammersSpot.Business.Models.Users.Contracts
{
    public interface IRegularUser
    {
        string Id { get; set; }

        string FirstName { get; set; }

        string LastName { get; set; }

        string Email { get; set; }

        string AvatarUrl { get; set; }

        string FacebookProfile { get; set; }

        string GitHubProfile { get; set; }

        int Age { get; set; }

        string JobTitle { get; set; }

        int StarsCount { get; set; }

        bool IsDeleted { get; set; }

        User User { get; set; }

        ICollection<Review> GivenReviews { get; set; }

        ICollection<Project> Projects { get; set; }

        ICollection<Skill> Skills { get; set; }

        ICollection<RegularUser> StarredUsers { get; set; }

        ICollection<FirmUser> StarredFirms { get; set; }
    }
}
