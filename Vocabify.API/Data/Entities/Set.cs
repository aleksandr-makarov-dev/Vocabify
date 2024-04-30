namespace Vocabify.API.Data.Entities
{
    public class Set:EntityBase
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
