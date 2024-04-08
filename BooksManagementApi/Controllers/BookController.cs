using Microsoft.AspNetCore.Mvc;
using BooksManagementApi.Models;
using BooksManagementApi.Commands;
using BooksManagementApi.Queries;

namespace BooksManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController(BookCommands commands, BookQueries queries) : ControllerBase
    {
        private readonly BookCommands _commands = commands;
        private readonly BookQueries _queries = queries;

        [HttpGet]
        public async Task<ActionResult<List<Book>>> GetBooks()
        {
            var books = await _queries.GetBooksAsync();

            return Ok(books);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            try
            {
                var book = await _queries.GetBookByIsbnAsync(id);
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
                await _commands.AddBookAsync(book);
                return Ok();
            }
            catch (ArgumentException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateBook(int id, [FromBody] Book book)
        {
            try
            {
                await _commands.UpdateBookAsync(id, book);
                return Ok();
            }
            catch (ArgumentException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            try
            {
                await _commands.DeleteBookAsync(id);
                return Ok();
            }
            catch (ArgumentException e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
