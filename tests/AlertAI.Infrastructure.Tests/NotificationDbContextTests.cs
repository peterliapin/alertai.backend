using AlertAI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace AlertAI.Infrastructure.Tests
{
    public class NotificationDbContextTests
    {
        [Fact]
        public void CanInstantiateDbContext()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<NotificationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            // Act
            using (var context = new NotificationDbContext(options))
            {
                // Assert
                Assert.NotNull(context);
            }
        }
    }
}