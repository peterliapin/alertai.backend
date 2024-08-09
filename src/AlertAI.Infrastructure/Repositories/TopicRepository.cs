using AlertAI.Core.Models;
using AlertAI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlertAI.Infrastructure.Repositories
{
    public class TopicRepository : ITopicRepository
    {
        private readonly NotificationDbContext _dbContext;

        public TopicRepository(NotificationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Topic>> GetAllTopicsAsync()
        {
            return await _dbContext.Topics.ToListAsync();
        }

        public async Task<Topic> GetTopicByIdAsync(int id)
        {
            return await _dbContext.Topics.FindAsync(id);
        }

        public async Task<Topic> CreateTopicAsync(Topic topic)
        {
            _dbContext.Topics.Add(topic);
            await _dbContext.SaveChangesAsync();
            return topic;
        }

        public async Task<Topic> UpdateTopicAsync(Topic topic)
        {
            _dbContext.Entry(topic).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return topic;
        }

        public async Task DeleteTopicAsync(int id)
        {
            var topic = await _dbContext.Topics.FindAsync(id);
            if (topic != null)
            {
                _dbContext.Topics.Remove(topic);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}