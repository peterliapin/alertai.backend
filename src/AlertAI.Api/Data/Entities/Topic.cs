using System.ComponentModel.DataAnnotations;

namespace AlertAI.Api.Data.Entities;

public class Topic : BaseEntity
{
    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    public string Context { get; set; } = string.Empty;
}