using AlertAI.Api.Controllers;
using AlertAI.Api.Data;
using AlertAI.Api.Data.Entities;
using AlertAI.Api.Interfaces;
using AlertAI.Api.Tests.TestServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace AlertAI.Api.Tests
{
    public class TopicsControllerTests : BaseTest
    {
        private TopicsController GetController(AlertAIDbContext dbContext)
        {
            var gptServiceMock = new Mock<IGptService>();
            gptServiceMock.Setup(s => s.GenerateResponse(It.IsAny<string>(), It.IsAny<int>()))
                          .ReturnsAsync("Generated Idea");

            var emailService = new TestEmailService();

            return new TopicsController(dbContext, gptServiceMock.Object, emailService);
        }

        [Fact]
        public void GetTopics_ReturnsOk()
        {
            // Arrange
            var dbContext = GetInMemoryDbContext();
            dbContext.Topics.Add(new Topic { Id = Guid.NewGuid(), Name = "Test Topic" });
            dbContext.SaveChanges();

            var controller = GetController(dbContext);

            // Act
            var actionResult = controller.GetTopics();
            var result = actionResult.Result;

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void GetTopic_ReturnsOk()
        {
            // Arrange
            var dbContext = GetInMemoryDbContext();
            var topicId = Guid.NewGuid();
            dbContext.Topics.Add(new Topic { Id = topicId, Name = "Test Topic" });
            dbContext.SaveChanges();

            var controller = GetController(dbContext);

            // Act
            var actionResult = controller.GetTopic(topicId);
            var result = actionResult.Result;

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void GetTopic_ReturnsNotFound()
        {
            // Arrange
            var dbContext = GetInMemoryDbContext();
            var controller = GetController(dbContext);

            // Act
            var actionResult = controller.GetTopic(Guid.NewGuid());
            var result = actionResult.Result;

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void CreateTopic_ReturnsCreatedAtAction()
        {
            // Arrange
            var dbContext = GetInMemoryDbContext();
            var controller = GetController(dbContext);
            var newTopic = new Topic { Id = Guid.NewGuid(), Name = "New Topic" };

            // Act
            var actionResult = controller.CreateTopic(newTopic);
            var result = actionResult.Result;

            // Assert
            Assert.IsType<CreatedAtActionResult>(result);
        }

        [Fact]
        public void UpdateTopic_ReturnsNoContent()
        {
            // Arrange
            var dbContext = GetInMemoryDbContext();
            var topicId = Guid.NewGuid();
            dbContext.Topics.Add(new Topic { Id = topicId, Name = "Old Topic" });
            dbContext.SaveChanges();

            var controller = GetController(dbContext);
            var updatedTopic = new Topic { Id = topicId, Name = "Updated Topic" };

            // Act
            var actionResult = controller.UpdateTopic(topicId, updatedTopic);

            // Assert
            Assert.IsType<NoContentResult>(actionResult);
        }

        [Fact]
        public void UpdateTopic_ReturnsNotFound()
        {
            // Arrange
            var dbContext = GetInMemoryDbContext();
            var controller = GetController(dbContext);
            var updatedTopic = new Topic { Id = Guid.NewGuid(), Name = "Updated Topic" };

            // Act
            var actionResult = controller.UpdateTopic(Guid.NewGuid(), updatedTopic);

            // Assert
            Assert.IsType<NotFoundResult>(actionResult);
        }

        [Fact]
        public void DeleteTopic_ReturnsNoContent()
        {
            // Arrange
            var dbContext = GetInMemoryDbContext();
            var topicId = Guid.NewGuid();
            dbContext.Topics.Add(new Topic { Id = topicId, Name = "Test Topic" });
            dbContext.SaveChanges();

            var controller = GetController(dbContext);

            // Act
            var actionResult = controller.DeleteTopic(topicId);

            // Assert
            Assert.IsType<NoContentResult>(actionResult);
        }

        [Fact]
        public void DeleteTopic_ReturnsNotFound()
        {
            // Arrange
            var dbContext = GetInMemoryDbContext();
            var controller = GetController(dbContext);

            // Act
            var actionResult = controller.DeleteTopic(Guid.NewGuid());

            // Assert
            Assert.IsType<NotFoundResult>(actionResult);
        }

        [Fact]
        public async Task SendIdea_ReturnsOk()
        {
            // Arrange
            var dbContext = GetInMemoryDbContext();
            var topicId = Guid.NewGuid();
            dbContext.Topics.Add(new Topic { Id = topicId, Name = "Test Topic", Context = "Test Context" });
            dbContext.SaveChanges();

            var controller = GetController(dbContext);

            // Act
            var actionResult = await controller.SendIdea(topicId);

            // Assert
            Assert.IsType<OkResult>(actionResult);
        }

        [Fact]
        public async Task SendIdea_ReturnsNotFound()
        {
            // Arrange
            var dbContext = GetInMemoryDbContext();
            var controller = GetController(dbContext);

            // Act
            var actionResult = await controller.SendIdea(Guid.NewGuid());

            // Assert
            Assert.IsType<NotFoundResult>(actionResult);
        }
    }
}