using System.ComponentModel.DataAnnotations;

namespace Vocabify.API.Data.Entities;

public class Term : EntityBase
{
    [Required]
    [MaxLength(250)]
    public required string Text { get; set; }
    [Required]
    [MaxLength(250)]
    public required string Definition { get; set; }
    public string? Image { get; set; }
    public string? TextTtsUrl { get; set; }
    public string? DefinitionTtsUrl { get; set; }
    public Guid SetId { get; set; }
}