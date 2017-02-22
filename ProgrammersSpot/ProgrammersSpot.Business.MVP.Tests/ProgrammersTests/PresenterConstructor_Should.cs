using System;
using NUnit.Framework;
using Moq;
using ProgrammersSpot.Business.MVP.Views;
using ProgrammersSpot.Business.MVP.Presenters;
using ProgrammersSpot.Business.Services.Contracts;
using ProgrammersSpot.Business.MVP.Tests.Mocks;

namespace ProgrammersSpot.Business.MVP.Tests.ProgrammersTests
{
    [TestFixture]
    public class PresenterConstructor_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenUserServiceIsNull()
        {
            //Arrange
            var viewMock = new Mock<IProgrammersView>();
            var skillServiceMock = new Mock<ISkillService>();

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => new ProgrammersPresenter(viewMock.Object, 
                null, skillServiceMock.Object));
        }

        [Test]
        public void ThrowArgumentNullException_WhenSkillServiceIsNull()
        {
            //Arrange
            var viewMock = new Mock<IProgrammersView>();
            var userServiceMock = new Mock<IUserService>();

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => new ProgrammersPresenter(viewMock.Object,
                userServiceMock.Object, null));
        }

        [Test]
        public void NotThrow_WhenValidParametersArePassed()
        {
            //Arrange
            var viewMock = new Mock<IProgrammersView>();
            var userServiceMock = new Mock<IUserService>();
            var skillServiceMock = new Mock<ISkillService>();

            //Act & Assert
            Assert.DoesNotThrow(() => new ProgrammersPresenter(viewMock.Object,
               userServiceMock.Object, skillServiceMock.Object));
        }

        [Test]
        public void InstantiateCorrectly_WhenValidParametersArePassed()
        {
            //Arrange
            var viewMock = new Mock<IProgrammersView>();
            var userServiceMock = new Mock<IUserService>();
            var skillServiceMock = new Mock<ISkillService>();

            //Act
            var presenter = new ProgrammersPresenterMock(viewMock.Object, userServiceMock.Object,
                skillServiceMock.Object);

            //Assert
            Assert.AreSame(userServiceMock.Object, presenter.UserService);
            Assert.AreSame(skillServiceMock.Object, presenter.SkillService);
        }
    }
}
