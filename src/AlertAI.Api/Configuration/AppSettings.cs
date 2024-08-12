namespace AlertAI.Api.Configuration;

public class BaseServiceConfig
{
    public string Server { get; set; } = string.Empty;

    public int Port { get; set; } = 0;

    public string UserName { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;
}

public class PostgresConfig : BaseServiceConfig
{
    public string Database { get; set; } = string.Empty;

    public string ConnectionString => $"User ID={UserName};Password={Password};Server={Server};Port={Port};Database={Database};Pooling=true;";
}

public class EmailConfig : BaseServiceConfig
{
    public bool UseSsl { get; set; }

    public string FromName { get; set; } = string.Empty;

    public string FromAddress { get; set; } = string.Empty;
}

public class OpenAIConfig
{
    public string ApiKey { get; set; } = string.Empty;
}