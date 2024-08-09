using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlertAI.Core.Models;

namespace AlertAI.Core.Services
{
    public class ScheduleService
    {
        private readonly List<Schedule> _schedules;

        public ScheduleService()
        {
            _schedules = new List<Schedule>();
        }

        public async Task<Schedule> CreateScheduleAsync(Schedule schedule)
        {
            // TODO: Implement logic to create a new schedule
            // Save the schedule to the database or any other storage mechanism
            // You can use the ScheduleRepository class for database operations

            // Example: Adding the schedule to the in-memory list
            _schedules.Add(schedule);

            return schedule;
        }

        public async Task<List<Schedule>> GetSchedulesAsync()
        {
            // TODO: Implement logic to retrieve all schedules
            // Retrieve the schedules from the database or any other storage mechanism
            // You can use the ScheduleRepository class for database operations

            // Example: Returning the in-memory list of schedules
            return _schedules;
        }

        public async Task<Schedule> GetScheduleByIdAsync(int id)
        {
            // TODO: Implement logic to retrieve a schedule by its ID
            // Retrieve the schedule from the database or any other storage mechanism
            // You can use the ScheduleRepository class for database operations

            // Example: Searching the in-memory list for a schedule with the specified ID
            return _schedules.FirstOrDefault(schedule => schedule.Id == id);
        }

        public async Task UpdateScheduleAsync(Schedule schedule)
        {
            // TODO: Implement logic to update a schedule
            // Update the schedule in the database or any other storage mechanism
            // You can use the ScheduleRepository class for database operations

            // Example: Updating the schedule in the in-memory list
            var existingSchedule = _schedules.FirstOrDefault(s => s.Id == schedule.Id);
            if (existingSchedule != null)
            {
                existingSchedule.TopicId = schedule.TopicId;
                existingSchedule.UserId = schedule.UserId;
                existingSchedule.NotificationType = schedule.NotificationType;
                existingSchedule.NotificationFrequency = schedule.NotificationFrequency;
                existingSchedule.PreferredTime = schedule.PreferredTime;
            }
        }

        public async Task DeleteScheduleAsync(int id)
        {
            // TODO: Implement logic to delete a schedule
            // Delete the schedule from the database or any other storage mechanism
            // You can use the ScheduleRepository class for database operations

            // Example: Removing the schedule from the in-memory list
            var schedule = _schedules.FirstOrDefault(s => s.Id == id);
            if (schedule != null)
            {
                _schedules.Remove(schedule);
            }
        }
    }
}