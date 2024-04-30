using System.Text.Json.Serialization;

namespace Vocabify.API.Modules.Sets.Models
{
    public class QuizletSet
    {


        [JsonPropertyName("lastModified")]
        public int LastModified { get; set; }

        [JsonPropertyName("wordLang")]
        public string WordLang { get; set; }

        [JsonPropertyName("defLang")]
        public string DefLang { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("numTerms")]
        public int NumTerms { get; set; }

        [JsonPropertyName("_webUrl")]
        public string WebUrl { get; set; }

        [JsonPropertyName("_thumbnailUrl")]
        public string ThumbnailUrl { get; set; }
    }

    public class DehydratedReduxStateKey
    {
        [JsonPropertyName("studyModesCommon")]
        public StudyModesCommon StudyModesCommon { get; set; }
        [JsonPropertyName("setPage")]
        public SetPage SetPage { get; set; }
    }

    public class Media
    {
        [JsonPropertyName("type")]
        public int Type { get; set; }

        [JsonPropertyName("plainText")]
        public string PlainText { get; set; }

        [JsonPropertyName("languageCode")]
        public string LanguageCode { get; set; }

        [JsonPropertyName("ttsUrl")]
        public string TtsUrl { get; set; }

        [JsonPropertyName("ttsSlowUrl")]
        public string TtsSlowUrl { get; set; }

        [JsonPropertyName("richText")]
        public object RichText { get; set; }

        [JsonPropertyName("code")]
        public string Code { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("width")]
        public int? Width { get; set; }

        [JsonPropertyName("height")]
        public int? Height { get; set; }

        [JsonPropertyName("attribution")]
        public string Attribution { get; set; }
    }

    public class PageProps
    {
        [JsonPropertyName("dehydratedReduxStateKey")]
        public string? DehydratedReduxStateKey { get; set; }
    }

    public class Props
    {
        [JsonPropertyName("pageProps")]
        public PageProps PageProps { get; set; }
    }

    public class QuizletResponse
    {
        [JsonPropertyName("props")]
        public Props Props { get; set; }
    }

    public class SetPage
    {
        [JsonPropertyName("set")]
        public QuizletSet Set { get; set; }
    }

    public class StudiableData
    {
        [JsonPropertyName("studiableItems")]
        public List<StudiableItem> StudiableItems { get; set; }
    }

    public class StudiableItem
    {
        [JsonPropertyName("id")]
        public object Id { get; set; }

        [JsonPropertyName("timestamp")]
        public int Timestamp { get; set; }

        [JsonPropertyName("cardSides")]
        public List<CardSide> CardSides { get; set; }
    }

    public class StudyModesCommon
    {
        [JsonPropertyName("studiableData")]
        public StudiableData StudiableData { get; set; }
    }

    public class CardSide
    {
        [JsonPropertyName("sideId")]
        public object SideId { get; set; }

        [JsonPropertyName("label")]
        public string Label { get; set; }

        [JsonPropertyName("media")]
        public List<Media> Media { get; set; }
    }
}
