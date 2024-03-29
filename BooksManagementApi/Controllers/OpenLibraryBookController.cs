using BooksManagementApi.Models;
using BooksManagementApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace BooksManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpenLibraryBookController(OpenLibraryService service) : ControllerBase
    {
        private readonly OpenLibraryService _service = service;

        [HttpGet("{searchTerm}")]
        public async Task<ActionResult<List<Book>>> GetBooks(string searchTerm)
        {
            if (searchTerm == null || searchTerm == "")
            {
                return BadRequest("Search term cannot be empty");
            }

            try
            {
                var books = await _service.GetBooksBySearchParamsAsync(searchTerm);
                return Ok(books);
            }
            catch (ArgumentException e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
