using System;
using System.Threading.Tasks;

namespace AlertAI.Infrastructure.Services
{
    public class PushNotificationService
    {
        public async Task SendPushNotification(string userId, string message)
        {
            // Code to send push notification to the user with the given userId and message
            Console.WriteLine($"Sending push notification to user {userId}: {message}");
            await Task.Delay(1000); // Simulating the push notification sending process
            Console.WriteLine("Push notification sent successfully");
        }
    }
}