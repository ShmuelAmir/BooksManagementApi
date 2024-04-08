using BooksManagementApi.Models;
using BooksManagementApi.Queries;
using Microsoft.AspNetCore.Mvc;

namespace BooksManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpenLibraryBookController(OpenLibraryQueries queries) : ControllerBase
    {
        private readonly OpenLibraryQueries _queries = queries;

        [HttpGet("{searchTerm}")]
        public async Task<ActionResult<List<Book>>> GetBooks(string searchTerm)
        {
            if (searchTerm == null || searchTerm == "")
            {
                return BadRequest("Search term cannot be empty");
            }

            try
            {
                var books = await _queries.GetBooksBySearchParamsAsync(searchTerm);
                return Ok(books);
            }
            catch (ArgumentException e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
