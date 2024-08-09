using AlertAI.Core.Models;
using AlertAI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlertAI.Infrastructure.Repositories
{
    public class ScheduleRepository : IScheduleRepository
    {
        private readonly NotificationDbContext _dbContext;

        public ScheduleRepository(NotificationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Schedule>> GetAllSchedulesAsync()
        {
            return await _dbContext.Schedules.ToListAsync();
        }

        public async Task<Schedule> GetScheduleByIdAsync(int id)
        {
            return await _dbContext.Schedules.FindAsync(id);
        }

        public async Task<IEnumerable<Schedule>> GetSchedulesByUserIdAsync(int userId)
        {
            return await _dbContext.Schedules
                .Where(s => s.UserId == userId)
                .ToListAsync();
        }

        public async Task AddScheduleAsync(Schedule schedule)
        {
            _dbContext.Schedules.Add(schedule);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateScheduleAsync(Schedule schedule)
        {
            _dbContext.Entry(schedule).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteScheduleAsync(int id)
        {
            var schedule = await _dbContext.Schedules.FindAsync(id);
            if (schedule != null)
            {
                _dbContext.Schedules.Remove(schedule);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}