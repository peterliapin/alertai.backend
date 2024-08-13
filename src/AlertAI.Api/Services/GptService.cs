using AlertAI.Api.Configuration;
using AlertAI.Api.Exceptions;
using AlertAI.Api.Interfaces;
using OpenAI.Chat;

namespace AlertAI.Api.Services;

public class GptService : IGptService
{

    private readonly OpenAIConfig openAIConfig = new();

    public GptService(IConfiguration configuration)
    {
        var settings = configuration.GetSection("OpenAI").Get<OpenAIConfig>();

        if (settings != null)
        {
            openAIConfig = settings;
        }
        else
        {
            throw new MissingConfigurationException($"The specified configuration section for the type {typeof(OpenAIConfig).FullName} could not be found in the settings file.");
        }
    }

    public async Task<string> GenerateResponse(string prompt, int maxTokens)
    {

    }
}
