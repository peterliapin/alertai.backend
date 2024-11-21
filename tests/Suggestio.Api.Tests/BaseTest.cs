using Suggestio.Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Suggestio.Api.Tests;

public class BaseTest
{
    protected SuggestioDbContext GetInMemoryDbContext()
    {
        var options = new DbContextOptionsBuilder<SuggestioDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;

        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .AddJsonFile("appsettings.tests.json")
            .Build();

        return new SuggestioDbContext(options, configuration);
    }
}
