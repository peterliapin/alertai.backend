using Xunit;

namespace AlertAI.Api.Tests
{
    public class UserControllerTests
    {
        [Fact]
        public void Test_GetUser_ReturnsUser()
        {
            // Arrange
            var controller = new UserController();

            // Act
            var result = controller.GetUser();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<User>(result);
        }

        [Fact]
        public void Test_CreateUser_ReturnsCreatedUser()
        {
            // Arrange
            var controller = new UserController();
            var newUser = new User { Name = "John Doe", Email = "johndoe@example.com" };

            // Act
            var result = controller.CreateUser(newUser);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<User>(result);
            Assert.Equal(newUser.Name, result.Name);
            Assert.Equal(newUser.Email, result.Email);
        }

        [Fact]
        public void Test_UpdateUser_ReturnsUpdatedUser()
        {
            // Arrange
            var controller = new UserController();
            var existingUser = new User { Id = 1, Name = "John Doe", Email = "johndoe@example.com" };
            var updatedUser = new User { Id = 1, Name = "Jane Smith", Email = "janesmith@example.com" };

            // Act
            var result = controller.UpdateUser(existingUser.Id, updatedUser);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<User>(result);
            Assert.Equal(updatedUser.Name, result.Name);
            Assert.Equal(updatedUser.Email, result.Email);
        }

        [Fact]
        public void Test_DeleteUser_ReturnsNoContent()
        {
            // Arrange
            var controller = new UserController();
            var userId = 1;

            // Act
            var result = controller.DeleteUser(userId);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }
    }
}