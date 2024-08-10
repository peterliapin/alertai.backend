using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace AlertAI.Api.Data;

public class AlertAIDbContextFactory : IDesignTimeDbContextFactory<AlertAIDbContext>
{
    public AlertAIDbContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", false)
            .AddEnvironmentVariables()
            .AddUserSecrets(typeof(Program).Assembly)
            .Build();

        var optionsBuilder = new DbContextOptionsBuilder<AlertAIDbContext>();

        return new AlertAIDbContext(optionsBuilder.Options, configuration);
    }
}
