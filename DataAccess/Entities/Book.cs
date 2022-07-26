using System.ComponentModel.DataAnnotations;

namespace DataAccess.Entities
{
    public sealed class Book
    {
        [Key]
        public long Isbn13 { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int PublishedYear { get; set; }
        public DateTime CreatedDateTime { get; set; }
    }
}
