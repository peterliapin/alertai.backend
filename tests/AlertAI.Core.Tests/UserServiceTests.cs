using Xunit;
using AlertAI.Core.Models;
using AlertAI.Core.Services;

namespace AlertAI.Core.Tests
{
    public class UserServiceTests
    {
        [Fact]
        public void CreateUser_ReturnsNewUser()
        {
            // Arrange
            var userService = new UserService();

            // Act
            var user = userService.CreateUser("John Doe");

            // Assert
            Assert.NotNull(user);
            Assert.Equal("John Doe", user.Name);
        }

        [Fact]
        public void GetUser_ReturnsExistingUser()
        {
            // Arrange
            var userService = new UserService();
            var existingUser = new User { Id = 1, Name = "Jane Smith" };

            // Act
            var user = userService.GetUser(1);

            // Assert
            Assert.NotNull(user);
            Assert.Equal(existingUser.Id, user.Id);
            Assert.Equal(existingUser.Name, user.Name);
        }

        [Fact]
        public void UpdateUser_UpdatesUserDetails()
        {
            // Arrange
            var userService = new UserService();
            var user = new User { Id = 1, Name = "John Doe" };
            var updatedName = "John Smith";

            // Act
            userService.UpdateUser(user, updatedName);

            // Assert
            Assert.Equal(updatedName, user.Name);
        }

        [Fact]
        public void DeleteUser_RemovesUser()
        {
            // Arrange
            var userService = new UserService();
            var user = new User { Id = 1, Name = "John Doe" };

            // Act
            userService.DeleteUser(user);

            // Assert
            Assert.Null(userService.GetUser(1));
        }
    }
}