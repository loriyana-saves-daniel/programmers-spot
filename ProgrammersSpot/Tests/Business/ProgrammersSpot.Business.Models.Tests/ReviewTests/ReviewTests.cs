using NUnit.Framework;
using ProgrammersSpot.Business.Common;
using ProgrammersSpot.Business.Models.Reviews;
using ProgrammersSpot.Business.Models.Users;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ProgrammersSpot.Business.Models.Tests.ReviewTests
{
    [TestFixture]
    public class ReviewTests
    {
        [TestCase(342)]
        [TestCase(2)]
        public void Id_ShouldBeSetAndGottenCorrectly(int reviewId)
        {
            // Arrange & Act
            var review = new Review() { Id = reviewId };

            //Assert
            Assert.AreEqual(review.Id, reviewId);
        }

        [TestCase("yeuyeuye eytruetryetrye retreryeryer")]
        [TestCase("LozenecLozenecLozenecLozenecLozenecLozenecLozenecLozenec")]
        public void Content_ShouldBeSetAndGottenCorrectly(string content)
        {
            // Arrange & Act
            var review = new Review() { Content = content };

            //Assert
            Assert.AreEqual(review.Content, content);
        }

        [Test]
        public void Content_ShouldHaveCorrectMinLength()
        {
            // Arrange
            var contentProperty = typeof(Review).GetProperty("Content");

            // Act
            var minLengthAttribute = contentProperty.GetCustomAttributes(typeof(MinLengthAttribute), false)
                .Cast<MinLengthAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(minLengthAttribute.Length, Is.Not.Null.And.EqualTo(Constants.MinReviewLength));
        }

        [Test]
        public void Content_ShouldHaveCorrectMaxLength()
        {
            // Arrange
            var contentProperty = typeof(Review).GetProperty("Content");

            // Act
            var maxLengthAttribute = contentProperty.GetCustomAttributes(typeof(MaxLengthAttribute), false)
                .Cast<MaxLengthAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(maxLengthAttribute.Length, Is.Not.Null.And.EqualTo(Constants.MaxReviewLength));
        }

        [TestCase(true)]
        [TestCase(false)]
        public void IsDeleted_ShouldBeSetAndGottenCorrectly(bool isDeleted)
        {
            // Arrange & Act
            var review = new Review() { IsDeleted = isDeleted };

            //Assert
            Assert.AreEqual(review.IsDeleted, isDeleted);
        }

        [TestCase("dhwdwhddh73783ge3e3ye7")]
        [TestCase("eugete762-2832ydf")]
        public void Author_ShouldBeSetAndGottenCorrectly(string testAuthorId)
        {
            // Arrange & Act         
            var user = new RegularUser { Id = testAuthorId };
            var review = new Review { Author = user };

            //Assert
            Assert.AreEqual(review.Author.Id, testAuthorId);
        }

        [TestCase("dhwdwhddh73783ge3e3ye7")]
        [TestCase("eugete762-2832ydf")]
        public void Firm_ShouldBeSetAndGottenCorrectly(string testFirmId)
        {
            // Arrange & Act         
            var firm = new FirmUser { Id = testFirmId };
            var review = new Review { Firm = firm };

            //Assert
            Assert.AreEqual(review.Firm.Id, testFirmId);
        }

        [TestCase("rhrerherejrgejhr")]
        [TestCase("3882739739778")]
        public void AuthorId_ShouldBeSetAndGottenCorrectly(string userId)
        {
            // Arrange & Act
            var review = new Review { AuthorId = userId };

            //Assert
            Assert.AreEqual(userId, review.AuthorId);
        }

        [TestCase("rhrerherejrgejhr")]
        [TestCase("3882739739778")]
        public void FirmId_ShouldBeSetAndGottenCorrectly(string firmId)
        {
            // Arrange & Act
            var review = new Review { FirmId = firmId };

            //Assert
            Assert.AreEqual(firmId, review.FirmId);
        }
    }
}
