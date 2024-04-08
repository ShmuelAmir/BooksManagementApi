using BooksManagementApi.Models;
using Microsoft.AspNetCore.Mvc;
using BooksManagementApi.Queries;

namespace BooksManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImaggaController(ImaggaQueries queries) : ControllerBase
    {
        private readonly ImaggaQueries _queries = queries;

        [HttpGet]
        public async Task<ActionResult<List<ImaggaTag>>> GetImagga(string imageUrl)
        {
            try
            {
                var tags = await _queries.GetTags(imageUrl);
                return Ok(tags);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
    }
}