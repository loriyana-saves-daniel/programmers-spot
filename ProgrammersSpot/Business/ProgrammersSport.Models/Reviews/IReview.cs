using ProgrammersSpot.Business.Models.Users;

namespace ProgrammersSpot.Business.Models.Reviews
{
    public interface IReview
    {
        int Id { get; set; }

        string Content { get; set; }

        bool IsDeleted { get; set; }

        string AuthorId { get; set; }

        RegularUser Author { get; set; }

        string FirmId { get; set; }

        FirmUser Firm { get; set; }
    }
}
