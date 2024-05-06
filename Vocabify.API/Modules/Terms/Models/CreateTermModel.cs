namespace Vocabify.API.Modules.Terms.Models
{
    public class CreateTermModel
    {
        public required string Text { get; set; }
        public required string Definition { get; set; }
        public string? Image { get; set; }
        public string? TextTtsUrl { get; set; }
        public string? DefinitionTtsUrl { get; set; }
        public Guid SetId { get; set; }
    }
}
