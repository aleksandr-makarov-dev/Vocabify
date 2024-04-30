namespace Vocabify.API.Data.Entities;

public class Term : EntityBase
{
    public required string Text { get; set; }
    public required string Definition { get; set; }
    public string? Image { get; set; }
    public string? TextTtsUrl { get; set; }
    public string? DefinitionTtsUrl { get; set; }
    public Guid SetId { get; set; }
}