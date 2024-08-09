using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlertAI.Core.Models;
using AlertAI.Infrastructure.Repositories;

namespace AlertAI.Core.Services
{
    public class TopicService
    {
        private readonly TopicRepository _topicRepository;

        public TopicService(TopicRepository topicRepository)
        {
            _topicRepository = topicRepository;
        }

        public async Task<List<Topic>> GetAllTopics()
        {
            return await _topicRepository.GetAllTopics();
        }

        public async Task<Topic> GetTopicById(int id)
        {
            return await _topicRepository.GetTopicById(id);
        }

        public async Task<Topic> CreateTopic(Topic topic)
        {
            return await _topicRepository.CreateTopic(topic);
        }

        public async Task<Topic> UpdateTopic(int id, Topic topic)
        {
            var existingTopic = await _topicRepository.GetTopicById(id);

            if (existingTopic == null)
            {
                throw new Exception("Topic not found");
            }

            existingTopic.Name = topic.Name;
            existingTopic.Description = topic.Description;

            return await _topicRepository.UpdateTopic(existingTopic);
        }

        public async Task DeleteTopic(int id)
        {
            var existingTopic = await _topicRepository.GetTopicById(id);

            if (existingTopic == null)
            {
                throw new Exception("Topic not found");
            }

            await _topicRepository.DeleteTopic(existingTopic);
        }
    }
}