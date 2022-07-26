namespace BookCollection.API.Models
{
    public class BookModel
    {
        public long Isbn13 { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int PublishedYear { get; set; }
    }
}
