namespace AlertAI.Api.Interfaces;

public interface IEmailService
{
    Task<string> SendEmail(string to, string subject, string body);
}