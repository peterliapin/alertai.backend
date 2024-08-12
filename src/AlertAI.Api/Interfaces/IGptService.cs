namespace AlertAI.Api.Interfaces;

public interface IGptService
{
    Task<string> GenerateResponse(string prompt, int maxTokens);
}
