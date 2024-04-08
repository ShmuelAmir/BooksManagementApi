using BooksManagementApi.Models;

namespace BooksManagementApi.Commands
{
    public class BookCommands(BookContext context)
    {
        private readonly BookContext _context = context;

        public async Task AddBookAsync(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateBookAsync(int id, Book book)
        {
            var dbBook = await _context.Books.FindAsync(id);
            if (dbBook == null)
            {
                throw new ArgumentException("Book with the specified id not found.");
            }

            dbBook.ISBN = book.ISBN;
            dbBook.Title = book.Title;
            dbBook.Author = book.Author;
            dbBook.PublishYear = book.PublishYear;
            dbBook.Cover = book.Cover;
            dbBook.Pages = book.Pages;
            dbBook.Rating = book.Rating;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteBookAsync(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                throw new ArgumentException("Book with the specified id not found.");
            }

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
        }
    }
}