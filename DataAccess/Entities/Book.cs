namespace DataAccess.Entities
{
    public sealed class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public long Isbn13 { get; set; }
        public int PublishedYear { get; set; }
    }
}
