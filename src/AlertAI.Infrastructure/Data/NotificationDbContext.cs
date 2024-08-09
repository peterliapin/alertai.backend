using Microsoft.EntityFrameworkCore;
using AlertAI.Core.Models;

namespace AlertAI.Infrastructure.Data
{
    public class NotificationDbContext : DbContext
    {
        public NotificationDbContext(DbContextOptions<NotificationDbContext> options) : base(options)
        {
        }

        public DbSet<Notification> Notifications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure the entity mappings and relationships here
            modelBuilder.Entity<Notification>()
                .HasKey(n => n.Id);

            // Add any additional configurations for other entities

            base.OnModelCreating(modelBuilder);
        }
    }
}