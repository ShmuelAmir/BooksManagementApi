using Microsoft.AspNetCore.Mvc;

using BooksManagementApi.Models;
using BooksManagementApi.Services;

namespace BooksManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController(BookService service) : ControllerBase
    {
        private readonly BookService _service = service;

        [HttpGet]
        public async Task<ActionResult<List<Book>>> GetBooks()
        {
            var books = await _service.GetBooksAsync();

            return Ok(books);
        }

        [HttpGet("{isbn}")]
        public async Task<ActionResult<Book>> GetBook(int isbn)
        {
            try
            {
                var book = await _service.GetBookByIsbnAsync(isbn);
                return Ok(book);
            }
            catch (ArgumentException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<List<Book>>> AddBook([FromBody] Book book)
        {
            try
            {
                await _service.AddBookAsync(book);
            }
            catch (ArgumentException e)
            {
                return NotFound(e.Message);
            }

            return Ok(await _service.GetBooksAsync());
        }

        [HttpPut("{isbn}")]
        public async Task<IActionResult> UpdateBook(int isbn, [FromBody] Book book)
        {
            try
            {
                await _service.UpdateBookAsync(isbn, book);
            }
            catch (ArgumentException e)
            {
                return NotFound(e.Message);
            }

            return Ok(await _service.GetBooksAsync());
        }

        [HttpDelete("{isbn}")]
        public async Task<IActionResult> DeleteBook(int isbn)
        {
            try
            {
                await _service.DeleteBookAsync(isbn);
            }
            catch (ArgumentException e)
            {
                return NotFound(e.Message);
            }

            return Ok(await _service.GetBooksAsync());
        }
    }
}
