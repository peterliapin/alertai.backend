using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Suggestio.Api.Data;

public class SuggestioDbContextFactory : IDesignTimeDbContextFactory<SuggestioDbContext>
{
    public SuggestioDbContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", false)
            .AddEnvironmentVariables()
            .AddUserSecrets(typeof(Program).Assembly)
            .Build();

        var optionsBuilder = new DbContextOptionsBuilder<SuggestioDbContext>();

        return new SuggestioDbContext(optionsBuilder.Options, configuration);
    }
}
