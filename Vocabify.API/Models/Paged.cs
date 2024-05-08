namespace Vocabify.API.Models
{
    public class Paged<T>
    {
        public int Page { get; set; }
        public IEnumerable<T> Items { get; set; }
        public bool HasNext { get; set; }
        public bool HasPrevious { get; set; }
    }
}
