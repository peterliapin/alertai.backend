using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace AlertAI.Infrastructure.Services
{
    public class EmailService
    {
        private readonly string _sendGridApiKey;

        public EmailService(string sendGridApiKey)
        {
            _sendGridApiKey = sendGridApiKey;
        }

        public async Task SendEmailAsync(string recipientEmail, string subject, string body)
        {
            var client = new SendGridClient(_sendGridApiKey);
            var from = new EmailAddress("noreply@alertai.com", "AlertAI");
            var to = new EmailAddress(recipientEmail);
            var message = MailHelper.CreateSingleEmail(from, to, subject, body, body);
            await client.SendEmailAsync(message);
        }
    }
}