using System.Net;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using AlertAI.Api.Interfaces;
using AlertAI.Api.Configuration;
using AlertAI.Api.Exceptions;

namespace AlertAI.Api.Services;

public class EmailService : IEmailService
{
    private readonly EmailConfig config = new();

    public EmailService(IConfiguration configuration)
    {
        var settings = configuration.GetSection("Email").Get<EmailConfig>();

        if (settings != null)
        {
            config = settings;
        }
        else
        {
            throw new MissingConfigurationException($"The specified configuration section for the type {typeof(EmailConfig).FullName} could not be found in the settings file.");
        }
    }

    public async Task<string> SendEmail(string to, string subject, string body)
    {
        var message = new MimeMessage();
        message.From.Add(new MailboxAddress(config.FromName, config.FromAddress));
        message.To.Add(new MailboxAddress(to));
        message.Subject = subject;

        var builder = new BodyBuilder
        {
            HtmlBody = body
        };

        message.Body = builder.ToMessageBody();

        using var client = new SmtpClient();
        await client.ConnectAsync(config.Server, config.Port, SecureSocketOptions.StartTls);
        await client.AuthenticateAsync(config.UserName, config.Password);
        await client.SendAsync(message);
        await client.DisconnectAsync(true);

        return HttpStatusCode.OK.ToString();    
    }
}
