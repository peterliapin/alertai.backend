using System;

namespace Suggestio.Api.Data.Entities;

public class Idea : BaseEntity
{
    public string Title { get; set; } = string.Empty;

    public string Content { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public Guid TopicId { get; set; }

    public Topic Topic { get; set; } = null!;

    public Guid ScheduleId { get; set; }

    public Schedule Schedule { get; set; } = null!;
}
