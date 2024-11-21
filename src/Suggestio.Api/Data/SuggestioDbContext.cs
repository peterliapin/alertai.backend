using Suggestio.Api.Configuration;
using Suggestio.Api.Data.Entities;
using Suggestio.Api.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Suggestio.Api.Data;

public class SuggestioDbContext : DbContext
{
    public readonly IConfiguration Configuration;

    public SuggestioDbContext(DbContextOptions<SuggestioDbContext> options, IConfiguration configuration) : base(options)
    {
        Configuration = configuration;
    }

    public virtual DbSet<Topic> Topics { get; set; }

    public virtual DbSet<Schedule> Schedules { get; set; }

    public virtual DbSet<Idea> Ideas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        try
        {
            if (optionsBuilder.IsConfigured)
            {
                // Prevents the configuration from being set more than once (e.g. when running tests)
                return;
            }

            Console.WriteLine("Configuring PgDbContext...");

            var postgresConfig = Configuration.GetSection("Postgres").Get<PostgresConfig>();

            if (postgresConfig == null)
            {
                throw new MissingConfigurationException("Postgres configuration is mandatory.");
            }

            optionsBuilder.UseNpgsql(
                postgresConfig.ConnectionString,
                b => b.MigrationsHistoryTable("_migrations"))
                .UseSnakeCaseNamingConvention();

            Console.WriteLine("PgDbContext successfully configured");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Failed to configure PgDbContext. Error: {0}, Stack Trace: {1}", ex.Message, ex.StackTrace);
            throw;
        }
    }
}
