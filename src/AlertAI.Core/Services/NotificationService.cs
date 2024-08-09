using System;
using System.Threading.Tasks;
using AlertAI.Core.Models;
using AlertAI.Infrastructure.Services;

namespace AlertAI.Core.Services
{
    public class NotificationService
    {
        private readonly EmailService _emailService;
        private readonly PushNotificationService _pushNotificationService;

        public NotificationService(EmailService emailService, PushNotificationService pushNotificationService)
        {
            _emailService = emailService;
            _pushNotificationService = pushNotificationService;
        }

        public async Task SendNotification(User user, Topic topic, Schedule schedule)
        {
            // Logic to send notification based on user's preferred schedule and notification type
            if (schedule.NotificationType == NotificationType.Email)
            {
                await _emailService.SendEmail(user.Email, $"New notification for topic: {topic.Name}", topic.Content);
            }
            else if (schedule.NotificationType == NotificationType.Push)
            {
                await _pushNotificationService.SendPushNotification(user.DeviceToken, $"New notification for topic: {topic.Name}", topic.Content);
            }
            else if (schedule.NotificationType == NotificationType.Both)
            {
                await _emailService.SendEmail(user.Email, $"New notification for topic: {topic.Name}", topic.Content);
                await _pushNotificationService.SendPushNotification(user.DeviceToken, $"New notification for topic: {topic.Name}", topic.Content);
            }
        }
    }
}