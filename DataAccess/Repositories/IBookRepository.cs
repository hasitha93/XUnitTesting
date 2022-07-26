using DataAccess.Entities;

namespace DataAccess.Repositories
{
    public interface IBookRepository
    {
        Task<bool> AddAsync(Book book);
        Task<Book> GetByIsbnAsync(long isbn13);
        Task<List<Book>> GetListAsync();
    }
}