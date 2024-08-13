using AlertAI.Api.Interfaces;

namespace AlertAI.Api.Tests.TestServices;

public class TestEmailService : IEmailService
{
    public Task<string> SendEmailAsync(string to, string subject, string body)
    {
        return new Task<string>(() => "OK");
    }
}
