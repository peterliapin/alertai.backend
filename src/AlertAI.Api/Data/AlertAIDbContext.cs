using AlertAI.Api.Configuration;
using AlertAI.Api.Data.Entities;
using AlertAI.Api.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace AlertAI.Api.Data;

public class AlertAIDbContext : DbContext
{
    public readonly IConfiguration Configuration;

    public AlertAIDbContext(DbContextOptions<AlertAIDbContext> options, IConfiguration configuration) : base(options)
    {
        Configuration = configuration;
    }

    public virtual DbSet<Topic> Topics { get; set; }

    public virtual DbSet<Schedule> Schedules { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        try
        {
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
