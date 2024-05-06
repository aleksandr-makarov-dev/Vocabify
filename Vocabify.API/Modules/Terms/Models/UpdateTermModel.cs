namespace Vocabify.API.Modules.Terms.Models
{
    public class UpdateTermModel
    {
        public string? Text { get; set; }
        public string? Definition { get; set; }
        public string? Image { get; set; }
        public string? TextTtsUrl { get; set; }
        public string? DefinitionTtsUrl { get; set; }
    }
}
