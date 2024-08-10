using System.ComponentModel.DataAnnotations;

namespace AlertAI.Api.Data.Entities;

public class Schedule : BaseEntity
{
    // Ical.Net is used to generate, store and parse the schedules, for more information see: https://github.com/rianjs/ical.net
    public string Ical { get; set; } = string.Empty;

    public bool OnDemand { get; set; } = true;

    [Required]
    public Guid TopicId { get; set; }
    
    public Topic Topic { get; set; } = null!;

    public bool IsEnabled { get; set; } = false;
}
