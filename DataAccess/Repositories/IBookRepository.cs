using DataAccess.Entities;

namespace DataAccess.Repositories
{
    public interface IBookRepository
    {
        Task<bool> AddAsync(Book product);
        Task<Book> GetByIdAsync(int id);
        Task<List<Book>> GetListAsync();
    }
}