using Microsoft.EntityFrameworkCore;
using BooksManagementApi.Models;

namespace BooksManagementApi.Services
{
    public class BookService(BookContext context)
    {
        private readonly BookContext _context = context;

        public async Task<List<Book>> GetBooksAsync()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task<Book> GetBookByIsbnAsync(int isbn)
        {
            var book = await _context.Books.FindAsync(isbn);

            if (book == null)
            {
                throw new ArgumentException("Book with the specified ISBN not found.");
            }

            return book;
        }

        public async Task<Book> AddBookAsync(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task UpdateBookAsync(int isbn, Book book)
        {
            var dbBook = await _context.Books.FindAsync(isbn);
            if (dbBook == null)
            {
                throw new ArgumentException("Book with the specified ISBN not found.");
            }

            dbBook.Title = book.Title;
            dbBook.Author = book.Author;
            dbBook.PublishYear = book.PublishYear;
            dbBook.Cover = book.Cover;
            dbBook.Pages = book.Pages;
            dbBook.Rating = book.Rating;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteBookAsync(int isbn)
        {
            var book = await _context.Books.FindAsync(isbn);
            if (book == null)
            {
                throw new ArgumentException("Book with the specified ISBN not found.");
            }

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
        }
    }

}
