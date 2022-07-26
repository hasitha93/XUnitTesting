using BookCollection.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookCollection.DataAccess.Repositories
{
    public sealed class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public BookRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<Book> GetByIsbnAsync(long isbn13)
        {
            var book = await _dbContext.Book.SingleOrDefaultAsync(b => b.Isbn13 == isbn13);
            return book;
        }

        public async Task<List<Book>> GetListAsync()
        {
            var books = await _dbContext.Book.ToListAsync();
            return books;
        }

        public async Task<bool> AddAsync(Book book)
        {
            book.CreatedDateTime = DateTime.UtcNow;
            await _dbContext.Book.AddAsync(book);
            var result = await _dbContext.SaveChangesAsync();
            return result > 0;
        }
    }
}
