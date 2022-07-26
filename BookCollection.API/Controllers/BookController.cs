using BookCollection.API.Extensions;
using BookCollection.API.Models;
using BookCollection.DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BookCollection.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepo;

        public BookController(IBookRepository bookRepo)
        {
            _bookRepo = bookRepo ?? throw new ArgumentNullException(nameof(bookRepo));
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetAllBooksAsync()
        {
            var books = await _bookRepo.GetListAsync();
            if (!books.Any()) return NoContent();

            var result = books.Select(b => b.ToBookModel()).ToList();
            return Ok(result);
        }

        [HttpGet("{isbn:long}")]
        public async Task<IActionResult> GetBookByIdAsync(long isbn)
        {
            var result = await _bookRepo.GetByIsbnAsync(isbn);
            if (result == null) return BadRequest();
            return Ok(result.ToBookModel());
        }

        [HttpPost]
        public async Task<IActionResult> AddBookAsync([FromBody] BookModel model)
        {
            var result = await _bookRepo.AddAsync(model.ToBook());
            return Ok(result);
        }
    }
}
