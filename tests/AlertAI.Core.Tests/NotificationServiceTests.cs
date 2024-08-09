using Xunit;
using AlertAI.Core.Services;

namespace AlertAI.Core.Tests
{
    public class NotificationServiceTests
    {
        [Fact]
        public void SendNotification_ShouldSendEmailAndPushNotification()
        {
            // Arrange
            var emailService = new EmailService();
            var pushNotificationService = new PushNotificationService();
            var notificationService = new NotificationService(emailService, pushNotificationService);

            // Act
            var result = notificationService.SendNotification("user@example.com", "New notification");

            // Assert
            Assert.True(result);
            // Add additional assertions as needed
        }

        [Fact]
        public void SendNotification_ShouldNotSendNotification_WhenInvalidEmail()
        {
            // Arrange
            var emailService = new EmailService();
            var pushNotificationService = new PushNotificationService();
            var notificationService = new NotificationService(emailService, pushNotificationService);

            // Act
            var result = notificationService.SendNotification("invalidemail", "New notification");

            // Assert
            Assert.False(result);
            // Add additional assertions as needed
        }

        // Add more test cases for the NotificationService class as needed
    }
}