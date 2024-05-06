namespace Vocabify.API.Modules.Sets.Models
{
    public class CreateSetModel
    {
        public required string Title { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public required string TextLang { get; set; }
        public required string DefinitionLang { get; set; }
    }
}
