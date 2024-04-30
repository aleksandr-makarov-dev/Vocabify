namespace Vocabify.API.Modules.Sets.Models
{
    public class CreateSetDto
    {
        public required string Title { get; set; }
        public required string Description { get; set; }
        public string? Image { get; set; }
        public required string TextLang { get; set; }
        public required string DefinitionLang { get; set; }
        public string? Url { get; set; }
        public int ItemsCount { get; set; }
    }
}
