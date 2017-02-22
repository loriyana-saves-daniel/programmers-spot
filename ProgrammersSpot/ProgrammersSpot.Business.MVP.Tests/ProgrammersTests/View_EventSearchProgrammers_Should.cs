using NUnit.Framework;
using Moq;
using ProgrammersSpot.Business.MVP.Views;
using ProgrammersSpot.Business.MVP.ViewModels;
using ProgrammersSpot.Business.Services.Contracts;
using System.Collections.Generic;
using ProgrammersSpot.Business.Models.Users;
using ProgrammersSpot.Business.MVP.Presenters;
using ProgrammersSpot.Business.MVP.Args;
using ProgrammersSpot.Business.Models.Skills;

namespace ProgrammersSpot.Business.MVP.Tests.ProgrammersTests
{
    [TestFixture]
    public class View_EventSearchProgrammers_Should
    {
        [Test]
        public void AddFoundProgrammersToViewModel_WhenRaised()
        {
            //Arrange
            var viewMock = new Mock<IProgrammersView>();
            viewMock.Setup(v => v.Model).Returns(new ProgrammersViewModel());

            var userService = new Mock<IUserService>();
            var skillService = new Mock<ISkillService>();

            
            var programmers = new List<RegularUser>()
            {
                new RegularUser()
                {
                    Id = "1",
                    Email = "user1@abv.bg",
                },
               new RegularUser()
                {
                    Id = "2",
                    Email = "user2@abv.bg"
                },
                new RegularUser()
                {
                    Id = "3",
                    Email = "user3@abv.bg"
                },
            };

            string keyword = "java";

            var skill = new Mock<Skill>();
            skill.Setup(s => s.Users).Returns(programmers);
            skillService.Setup(s => s.GetSkillByName(keyword)).Returns(skill.Object);

            var presenter = new ProgrammersPresenter(viewMock.Object, userService.Object,
                skillService.Object);

            //Act
            viewMock.Raise(v => v.EventSearchProgrammers += null, new SearchEventArgs(keyword));

            //Assert
            CollectionAssert.AreEquivalent(programmers, viewMock.Object.Model.Programmers);
        }
    }
}
