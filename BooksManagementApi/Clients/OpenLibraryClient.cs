using RestSharp;
using BooksManagementApi.Models;

namespace BooksManagementApi.Clients
{
    public class OpenLibraryClient
    {
        private readonly RestClient _client = new RestClient("https://openlibrary.org");

        public async Task<OpenLibraryBookResponse> GetBooks(string endpoint)
        {
            var response = await _client.GetJsonAsync<OpenLibraryBookResponse>(endpoint);

            if (response == null)
            {
                throw new Exception("Failed to fetch books from OpenLibrary API");
            }

            return response;
        }

        public record OpenLibraryBookResponse(List<OpenLibraryBook> docs);
    }
}
