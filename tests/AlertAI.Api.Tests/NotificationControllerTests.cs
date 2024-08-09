using Xunit;
using AlertAI.Api.Controllers;
using AlertAI.Core.Models;
using AlertAI.Core.Services;
using Moq;

namespace AlertAI.Api.Tests
{
    public class NotificationControllerTests
    {
        [Fact]
        public void GetNotification_ReturnsNotification()
        {
            // Arrange
            var mockNotificationService = new Mock<INotificationService>();
            var notification = new Notification { Id = 1, Message = "Test notification" };
            mockNotificationService.Setup(service => service.GetNotificationById(It.IsAny<int>())).Returns(notification);
            var controller = new NotificationController(mockNotificationService.Object);

            // Act
            var result = controller.GetNotification(1);

            // Assert
            Assert.Equal(notification, result.Value);
        }

        [Fact]
        public void CreateNotification_ReturnsCreatedNotification()
        {
            // Arrange
            var mockNotificationService = new Mock<INotificationService>();
            var notification = new Notification { Id = 1, Message = "Test notification" };
            mockNotificationService.Setup(service => service.CreateNotification(It.IsAny<Notification>())).Returns(notification);
            var controller = new NotificationController(mockNotificationService.Object);

            // Act
            var result = controller.CreateNotification(notification);

            // Assert
            Assert.Equal(notification, result.Value);
        }

        [Fact]
        public void DeleteNotification_ReturnsNoContent()
        {
            // Arrange
            var mockNotificationService = new Mock<INotificationService>();
            var controller = new NotificationController(mockNotificationService.Object);

            // Act
            var result = controller.DeleteNotification(1);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }
    }
}