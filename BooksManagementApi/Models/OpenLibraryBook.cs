namespace BooksManagementApi.Models
{
    public class OpenLibraryBook
    {
        public string[] isbn { get; set; } = Array.Empty<string>();
        public string title { get; set; } = string.Empty;
        public string[] author_name { get; set; } = Array.Empty<string>();
        public int first_publish_year { get; set; }
        public int cover_i { get; set; }
        public int number_of_pages_median { get; set; }
        public float ratings_average { get; set; }
    }
}
