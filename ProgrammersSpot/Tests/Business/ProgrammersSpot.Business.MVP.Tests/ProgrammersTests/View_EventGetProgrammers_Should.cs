using System;
using NUnit.Framework;
using Moq;
using ProgrammersSpot.Business.MVP.Views;
using ProgrammersSpot.Business.MVP.ViewModels;
using ProgrammersSpot.Business.Models.Users;
using System.Collections.Generic;
using ProgrammersSpot.Business.Services.Contracts;
using System.Linq;
using ProgrammersSpot.Business.MVP.Presenters;

namespace ProgrammersSpot.Business.MVP.Tests.ProgrammersTests
{
    [TestFixture]
    public class View_EventGetProgrammers_Should
    {
        [Test]
        public void AddProgrammersToViewModel_WhenRaised()
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
                    Email = "user1@abv.bg"
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
            }.AsQueryable();
            userService.Setup(s => s.GetAllRegularUsers()).Returns(programmers);

            var presenter = new ProgrammersPresenter(viewMock.Object, userService.Object, 
                skillService.Object);

            //Act
            viewMock.Raise(v => v.EventGetProgrammers += null, EventArgs.Empty);

            //Assert
            CollectionAssert.AreEquivalent(programmers, viewMock.Object.Model.Programmers);
        }
    }
}
