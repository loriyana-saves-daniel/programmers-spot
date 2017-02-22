using NUnit.Framework;
using ProgrammersSpot.Business.Common;
using ProgrammersSpot.Business.Models.Projects;
using ProgrammersSpot.Business.Models.Users;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ProgrammersSpot.Business.Models.Tests.ProjectTests
{
    [TestFixture]
    public class ProjectTests
    {
        [TestCase(342)]
        [TestCase(2)]
        public void Id_ShouldBeSetAndGottenCorrectly(int projectId)
        {
            // Arrange & Act
            var project = new Project() { Id = projectId };

            //Assert
            Assert.AreEqual(project.Id, projectId);
        }

        [TestCase("My Project")]
        [TestCase("Web App")]
        public void Name_ShouldBeSetAndGottenCorrectly(string name)
        {
            // Arrange & Act
            var project = new Project() { Name = name };

            //Assert
            Assert.AreEqual(project.Name, name);
        }

        [TestCase("yeuyeuye eytruetryetrye retreryeryer")]
        [TestCase("LozenecLozenecLozenecLozenecLozenecLozenecLozenecLozenec")]
        public void Description_ShouldBeSetAndGottenCorrectly(string content)
        {
            // Arrange & Act
            //var project = new Project() { Description = content };

            ////Assert
            //Assert.AreEqual(project.Description, content);
        }

        [TestCase("yeuyeuye eytruetryetrye retreryeryer")]
        [TestCase("LozenecLozenecLozenecLozenecLozenecLozenecLozenecLozenec")]
        public void LinkToProject_ShouldBeSetAndGottenCorrectly(string link)
        {
            // Arrange & Act
            var project = new Project() { LinkToProject = link };

            //Assert
            Assert.AreEqual(project.LinkToProject, link);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void IsDeleted_ShouldBeSetAndGottenCorrectly(bool isDeleted)
        {
            // Arrange & Act
            var project = new Project() { IsDeleted = isDeleted };

            //Assert
            Assert.AreEqual(project.IsDeleted, isDeleted);
        }

        [TestCase("dhwdwhddh73783ge3e3ye7")]
        [TestCase("eugete762-2832ydf")]
        public void Author_ShouldBeSetAndGottenCorrectly(string testAuthorId)
        {
            // Arrange & Act         
            var user = new RegularUser { Id = testAuthorId };
            var project = new Project { Author = user };

            //Assert
            Assert.AreEqual(project.Author.Id, testAuthorId);
        }

        [TestCase("rhrerherejrgejhr")]
        [TestCase("3882739739778")]
        public void AuthorId_ShouldBeSetAndGottenCorrectly(string userId)
        {
            // Arrange & Act
            var project = new Project { AuthorId = userId };

            //Assert
            Assert.AreEqual(userId, project.AuthorId);
        }
    }
}
