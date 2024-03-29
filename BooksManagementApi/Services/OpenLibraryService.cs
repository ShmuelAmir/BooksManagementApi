using BooksManagementApi.Models;
using BooksManagementApi.Clients;

namespace BooksManagementApi.Services
{
    public class OpenLibraryService
    {
        readonly OpenLibraryClient _openLibraryClient = new OpenLibraryClient();

        public async Task<List<Book>> GetBooksBySearchParamsAsync(string searchTerm)
        {
            var response = await _openLibraryClient.GetBooksBySearchParamsAsync(searchTerm);

            if (response.docs == null)
            {
                throw new Exception("No books found for the given search term");
            }

            return response.docs
                .Where(IsValidBook)
                .DistinctBy(olb => olb.title)
                .Take(10)
                .Select(OpenLibraryBookToDBBookConvertor)
                .ToList();
        }

        private bool IsValidBook(OpenLibraryBook openLibBook)
        {
            return openLibBook.isbn != null 
                && openLibBook.author_name != null 
                && openLibBook.isbn.Length > 0 
                && openLibBook.author_name.Length > 0;
        }

        private Book OpenLibraryBookToDBBookConvertor(OpenLibraryBook openLibBook)
        {
            return new Book
            {
                ISBN = openLibBook.isbn[0],
                Title = openLibBook.title,
                Author = openLibBook.author_name[0],
                PublishYear = openLibBook.first_publish_year,
                Cover = $"https://covers.openlibrary.org/b/id/{openLibBook.cover_i}-L.jpg",
                Pages = openLibBook.number_of_pages_median,
                Rating = openLibBook.ratings_average
            };
        }

    }
}
