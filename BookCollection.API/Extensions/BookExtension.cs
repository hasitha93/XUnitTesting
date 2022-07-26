using BookCollection.API.Models;
using BookCollection.DataAccess.Entities;

namespace BookCollection.API.Extensions
{
    public static class BookExtension
    {
        public static Book ToBook(this BookModel model)
        {
            return new Book
            {
                Title = model.Title,
                Author = model.Author,
                Isbn13 = model.Isbn13,
                PublishedYear = model.PublishedYear
            };
        }

        public static BookModel ToBookModel(this Book book)
        {
            return new BookModel
            {
                Title = book.Title,
                Author = book.Author,
                Isbn13 = book.Isbn13,
                PublishedYear = book.PublishedYear
            };
        }
    }
}
