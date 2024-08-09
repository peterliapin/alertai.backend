using Xunit;

namespace AlertAI.Api.Tests
{
    public class ScheduleControllerTests
    {
        [Fact]
        public void Test_GetScheduleById()
        {
            // Arrange
            var controller = new ScheduleController();

            // Act
            var result = controller.GetScheduleById(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
        }

        [Fact]
        public void Test_CreateSchedule()
        {
            // Arrange
            var controller = new ScheduleController();
            var schedule = new Schedule { Id = 1, Name = "Daily", Frequency = Frequency.Daily };

            // Act
            var result = controller.CreateSchedule(schedule);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
        }

        [Fact]
        public void Test_UpdateSchedule()
        {
            // Arrange
            var controller = new ScheduleController();
            var schedule = new Schedule { Id = 1, Name = "Weekly", Frequency = Frequency.Weekly };

            // Act
            var result = controller.UpdateSchedule(schedule);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
            Assert.Equal("Weekly", result.Name);
        }

        [Fact]
        public void Test_DeleteSchedule()
        {
            // Arrange
            var controller = new ScheduleController();

            // Act
            var result = controller.DeleteSchedule(1);

            // Assert
            Assert.True(result);
        }
    }
}