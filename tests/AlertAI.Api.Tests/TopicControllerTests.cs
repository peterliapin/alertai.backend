using System;
using Xunit;
using Moq;
using AlertAI.Core.Models;
using AlertAI.Core.Services;
using AlertAI.Api.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace AlertAI.Api.Tests
{
    public class TopicControllerTests
    {
        private readonly TopicController _controller;
        private readonly Mock<ITopicService> _topicServiceMock;

        public TopicControllerTests()
        {
            _topicServiceMock = new Mock<ITopicService>();
            _controller = new TopicController(_topicServiceMock.Object);
        }

        [Fact]
        public void GetTopic_WithValidId_ReturnsOkResult()
        {
            // Arrange
            int topicId = 1;
            var topic = new Topic { Id = topicId, Name = "Example Topic" };
            _topicServiceMock.Setup(service => service.GetTopic(topicId)).Returns(topic);

            // Act
            var result = _controller.GetTopic(topicId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedTopic = Assert.IsType<Topic>(okResult.Value);
            Assert.Equal(topicId, returnedTopic.Id);
            Assert.Equal("Example Topic", returnedTopic.Name);
        }

        [Fact]
        public void GetTopic_WithInvalidId_ReturnsNotFoundResult()
        {
            // Arrange
            int topicId = 1;
            _topicServiceMock.Setup(service => service.GetTopic(topicId)).Returns((Topic)null);

            // Act
            var result = _controller.GetTopic(topicId);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        // Add more test cases for other actions in the TopicController
    }
}