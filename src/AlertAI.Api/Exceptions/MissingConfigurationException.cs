namespace AlertAI.Api.Exceptions;

public class MissingConfigurationException : Exception
{
    public MissingConfigurationException(string message) : base(message)
    {
    }
}