using Xunit;

namespace AlertAI.Infrastructure.Tests
{
    public class UserRepositoryTests
    {
        [Fact]
        public void Test_GetUserById()
        {
            // Arrange
            var userRepository = new UserRepository();

            // Act
            var user = userRepository.GetUserById(1);

            // Assert
            Assert.NotNull(user);
            Assert.Equal(1, user.Id);
        }

        [Fact]
        public void Test_CreateUser()
        {
            // Arrange
            var userRepository = new UserRepository();
            var newUser = new User { Id = 2, Name = "John Doe" };

            // Act
            userRepository.CreateUser(newUser);
            var createdUser = userRepository.GetUserById(2);

            // Assert
            Assert.NotNull(createdUser);
            Assert.Equal(2, createdUser.Id);
            Assert.Equal("John Doe", createdUser.Name);
        }

        [Fact]
        public void Test_UpdateUser()
        {
            // Arrange
            var userRepository = new UserRepository();
            var user = userRepository.GetUserById(1);
            user.Name = "Updated Name";

            // Act
            userRepository.UpdateUser(user);
            var updatedUser = userRepository.GetUserById(1);

            // Assert
            Assert.NotNull(updatedUser);
            Assert.Equal(1, updatedUser.Id);
            Assert.Equal("Updated Name", updatedUser.Name);
        }

        [Fact]
        public void Test_DeleteUser()
        {
            // Arrange
            var userRepository = new UserRepository();
            var user = userRepository.GetUserById(1);

            // Act
            userRepository.DeleteUser(user);
            var deletedUser = userRepository.GetUserById(1);

            // Assert
            Assert.Null(deletedUser);
        }
    }
}