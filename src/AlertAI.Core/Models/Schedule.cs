using System;

namespace AlertAI.Core.Models
{
    public class Schedule
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int TopicId { get; set; }
        public NotificationType NotificationType { get; set; }
        public TimeSpan TimeOfDay { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        // Navigation properties
        public User User { get; set; }
        public Topic Topic { get; set; }
    }

    public enum NotificationType
    {
        Email,
        Push,
        Both
    }
}