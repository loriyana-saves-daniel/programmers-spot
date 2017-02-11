﻿using ProgrammersSpot.Business.Models.Users;

namespace ProgrammersSpot.Business.Models.Reviews
{
    public interface IReview
    {
        int Id { get; set; }

        string Content { get; set; }

        bool IsDeleted { get; set; }

        string AuthorId { get; set; }

        User Author { get; set; }
    }
}
