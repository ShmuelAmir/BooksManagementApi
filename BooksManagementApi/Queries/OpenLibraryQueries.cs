using BooksManagementApi.Models;
using BooksManagementApi.Clients;

namespace BooksManagementApi.Queries
{
    public class OpenLibraryQueries
    {
        const int MAX_BOOKS = 10;
        readonly OpenLibraryClient _openLibraryClient = new OpenLibraryClient();

        public async Task<List<Book>> GetBooksBySearchParamsAsync(string searchTerm)
        {
            var response = await _openLibraryClient.GetBooks($"/search.json?q={searchTerm}");

            if (response.docs == null)
            {
                throw new Exception("No books found for the given search term");
            }

            return response.docs
                .Where(olb => olb.IsValidBook())
                .Where(olb => olb.IsEnglishBook())
                .DistinctBy(olb => olb.title)
                .Take(MAX_BOOKS)
                .Select(OpenLibraryBookToDBBookConvertor)
                .ToList();
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
