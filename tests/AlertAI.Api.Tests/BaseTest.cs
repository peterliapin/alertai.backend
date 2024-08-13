using AlertAI.Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AlertAI.Api.Tests;

public class BaseTest
{
    protected AlertAIDbContext GetInMemoryDbContext()
    {
        var options = new DbContextOptionsBuilder<AlertAIDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;

        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .AddJsonFile("appsettings.tests.json")
            .Build();

        return new AlertAIDbContext(options, configuration);
    }
}
