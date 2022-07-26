using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public sealed class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public BookRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<Book> GetByIdAsync(int id)
        {
            var product = await _dbContext.Book.SingleOrDefaultAsync(b => b.Id == id);
            return product;
        }

        public async Task<List<Book>> GetListAsync()
        {
            var products = await _dbContext.Book.ToListAsync();
            return products;
        }

        public async Task<bool> AddAsync(Book product)
        {
            await _dbContext.Book.AddAsync(product);
            var result = await _dbContext.SaveChangesAsync();
            return result > 0;
        }
    }
}
