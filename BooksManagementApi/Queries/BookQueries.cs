using Microsoft.EntityFrameworkCore;
using BooksManagementApi.Models;

namespace BooksManagementApi.Queries
{
    public class BookQueries(BookContext context)
    {
        private readonly BookContext _context = context;

        public async Task<List<Book>> GetBooksAsync()
        {
            return await _context.Books.ToListAsync(); // Include("Tags")
        }

        public async Task<Book> GetBookByIsbnAsync(int id)
        {
            var book = await _context.Books.FindAsync(id);

            if (book == null)
            {
                throw new ArgumentException("Book with the specified id not found.");
            }

            return book;
        }
    }
}