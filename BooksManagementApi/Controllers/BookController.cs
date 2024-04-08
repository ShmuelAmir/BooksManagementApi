﻿using Microsoft.AspNetCore.Mvc;
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

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            try
            {
                var book = await _service.GetBookByIsbnAsync(id);
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
                await _service.UpdateBookAsync(id, book);
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
                await _service.DeleteBookAsync(id);
                return Ok();
            }
            catch (ArgumentException e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
