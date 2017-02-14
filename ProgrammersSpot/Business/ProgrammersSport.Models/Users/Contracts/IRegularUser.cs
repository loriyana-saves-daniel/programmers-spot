﻿using ProgrammersSpot.Business.Models.Skills;
using ProgrammersSpot.Business.Models.Projects;
using ProgrammersSpot.Business.Models.Reviews;
using System;
using System.Collections.Generic;

namespace ProgrammersSpot.Business.Models.Users.Contracts
{
    public interface IRegularUser
    {
        string Id { get; set; }

        string FirstName { get; set; }

        string LastName { get; set; }

        int Age { get; set; }

        string JobTitle { get; set; }

        bool IsDeleted { get; set; }

        User User { get; set; }

        ICollection<IReview> GivenReviews { get; set; }

        ICollection<IProject> Projects { get; set; }

        ICollection<ISkill> Skills { get; set; }
    }
}
