using BookCollection.API.Models;
using BookCollection.DataAccess.Entities;

namespace BookCollection.UnitTests.MockData
{
    public class BookMockData
    {
        public static List<Book> GetBookList()
        {
            return new List<Book>
            {
                new Book
                {
                    Isbn13 = 1234567890111,
                    Title = "Book 1",
                    Author = "Author 1",
                    PublishedYear = 2001,
                    CreatedDateTime = DateTime.UtcNow,
                },
                new Book
                {
                    Isbn13 = 1234567890222,
                    Title = "Book 2",
                    Author = "Author 2",
                    PublishedYear = 2002,
                    CreatedDateTime = DateTime.UtcNow,
                },
                new Book
                {
                    Isbn13 = 1234567890333,
                    Title = "Book 3",
                    Author = "Author 3",
                    PublishedYear = 2003,
                    CreatedDateTime = DateTime.UtcNow,
                }
            };
        }

        public static List<Book> GetEmptyBookList() => new();

        public static BookModel NewBookModel()
        {
            return new BookModel
            {
                Isbn13 = 1234567890444,
                Title = "Book 4",
                Author = "Author 4",
                PublishedYear = 2004
            };
        }
    }
}
