using Xunit;

namespace AlertAI.Infrastructure.Tests
{
    public class TopicRepositoryTests
    {
        [Fact]
        public void Test_GetTopicById()
        {
            // Arrange
            var topicRepository = new TopicRepository();

            // Act
            var topic = topicRepository.GetTopicById(1);

            // Assert
            Assert.NotNull(topic);
            Assert.Equal(1, topic.Id);
        }

        [Fact]
        public void Test_AddTopic()
        {
            // Arrange
            var topicRepository = new TopicRepository();
            var topic = new Topic { Id = 2, Name = "Sample Topic" };

            // Act
            topicRepository.AddTopic(topic);

            // Assert
            var addedTopic = topicRepository.GetTopicById(2);
            Assert.NotNull(addedTopic);
            Assert.Equal("Sample Topic", addedTopic.Name);
        }

        [Fact]
        public void Test_UpdateTopic()
        {
            // Arrange
            var topicRepository = new TopicRepository();
            var topic = new Topic { Id = 1, Name = "Updated Topic" };

            // Act
            topicRepository.UpdateTopic(topic);

            // Assert
            var updatedTopic = topicRepository.GetTopicById(1);
            Assert.NotNull(updatedTopic);
            Assert.Equal("Updated Topic", updatedTopic.Name);
        }

        [Fact]
        public void Test_DeleteTopic()
        {
            // Arrange
            var topicRepository = new TopicRepository();

            // Act
            topicRepository.DeleteTopic(1);

            // Assert
            var deletedTopic = topicRepository.GetTopicById(1);
            Assert.Null(deletedTopic);
        }
    }
}