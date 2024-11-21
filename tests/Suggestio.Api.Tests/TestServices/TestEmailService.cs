using Suggestio.Api.Interfaces;

namespace Suggestio.Api.Tests.TestServices;

public class TestEmailService : IEmailService
{
    public Task<string> SendEmailAsync(string to, string subject, string body)
    {
        return new Task<string>(() => "OK");
    }
}
