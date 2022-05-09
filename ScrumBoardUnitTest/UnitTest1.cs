using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScrumBoardLib.model;

namespace ScrumBoardUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [DataRow("Alf")]
        public void TestTitle(string Title)
        {

            // Arrange
            UserStory us = new UserStory();
            string expectedValue = Title;

            // Act
            us.Title = Title;
            string actualValue = us.Title;

            // Assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        [DataRow("T")]
        public void TestTitle2(string Title)
        {

            // Arrange
            UserStory us = new UserStory();

            // Act

            // Assert
            Assert.ThrowsException<ArgumentException>(() => us.Title = Title);
        }

        [TestMethod]
        [DataRow("HowDoYouBreatheOxygen")]
        public void TestDescription(string description)
        {

            // Arrange
            UserStory us = new UserStory();
            string expectedValue = description;

            // Act
            us.Description = description;
            string actualValue = us.Description;
            // Assert
            Assert.AreEqual(expectedValue,  actualValue);
        }

        [TestMethod]
        [DataRow("T")]
        public void TestDescription2(string description)
        {

            // Arrange
            UserStory us = new UserStory();
            string expectedValue = description;

            // Act

            // Assert
            Assert.ThrowsException<ArgumentException>(() => us.Title = description);
        }

        [TestMethod]
        [DataRow(2)]
        public void TestBusinessValue(int businessValue)
        {

            // Arrange
            UserStory us = new UserStory();
            int expectedValue = businessValue;

            // Act
            us.BusinessValue = businessValue;
            int actualValue = us.BusinessValue;
            // Assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        [DataRow(32454325)]
        [DataRow(3245)]
        [DataRow(35)]
        [DataRow(-5)]
        public void TestBusinessValue2(int businessValue)
        {

            // Arrange
            UserStory us = new UserStory();

            // Act

            // Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => us.BusinessValue = businessValue);
        }

        [TestMethod]
        [DataRow(2)]
        public void TestStoryPoints(int storyPoints)
        {

            // Arrange
            UserStory us = new UserStory();
            int expectedValue = storyPoints;

            // Act
            us.StoryPoints = storyPoints;
            int actualValue = us.StoryPoints;
            // Assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        [DataRow(-32454325)]
        [DataRow(-3245)]
        [DataRow(-35)]
        [DataRow(-5)]
        [DataRow(0)]
        public void TestStoryPoints2(int storyPoints)
        {

            // Arrange
            UserStory us = new UserStory();

            // Act

            // Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => us.StoryPoints = storyPoints);
        }
    }
}
