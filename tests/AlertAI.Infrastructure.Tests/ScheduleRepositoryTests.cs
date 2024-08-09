using Xunit;

namespace AlertAI.Infrastructure.Tests
{
    public class ScheduleRepositoryTests
    {
        [Fact]
        public void Test_GetScheduleById()
        {
            // Arrange
            var repository = new ScheduleRepository();
            var scheduleId = 1;

            // Act
            var schedule = repository.GetScheduleById(scheduleId);

            // Assert
            Assert.NotNull(schedule);
            Assert.Equal(scheduleId, schedule.Id);
        }

        [Fact]
        public void Test_CreateSchedule()
        {
            // Arrange
            var repository = new ScheduleRepository();
            var schedule = new Schedule
            {
                Id = 1,
                UserId = 1,
                TopicId = 1,
                Frequency = Frequency.Daily,
                NotificationType = NotificationType.Email
            };

            // Act
            repository.CreateSchedule(schedule);

            // Assert
            var createdSchedule = repository.GetScheduleById(schedule.Id);
            Assert.NotNull(createdSchedule);
            Assert.Equal(schedule.Id, createdSchedule.Id);
            Assert.Equal(schedule.UserId, createdSchedule.UserId);
            Assert.Equal(schedule.TopicId, createdSchedule.TopicId);
            Assert.Equal(schedule.Frequency, createdSchedule.Frequency);
            Assert.Equal(schedule.NotificationType, createdSchedule.NotificationType);
        }

        [Fact]
        public void Test_UpdateSchedule()
        {
            // Arrange
            var repository = new ScheduleRepository();
            var scheduleId = 1;
            var updatedSchedule = new Schedule
            {
                Id = scheduleId,
                UserId = 1,
                TopicId = 1,
                Frequency = Frequency.Weekly,
                NotificationType = NotificationType.Push
            };

            // Act
            repository.UpdateSchedule(updatedSchedule);

            // Assert
            var schedule = repository.GetScheduleById(scheduleId);
            Assert.NotNull(schedule);
            Assert.Equal(scheduleId, schedule.Id);
            Assert.Equal(updatedSchedule.Frequency, schedule.Frequency);
            Assert.Equal(updatedSchedule.NotificationType, schedule.NotificationType);
        }

        [Fact]
        public void Test_DeleteSchedule()
        {
            // Arrange
            var repository = new ScheduleRepository();
            var scheduleId = 1;

            // Act
            repository.DeleteSchedule(scheduleId);

            // Assert
            var schedule = repository.GetScheduleById(scheduleId);
            Assert.Null(schedule);
        }
    }
}