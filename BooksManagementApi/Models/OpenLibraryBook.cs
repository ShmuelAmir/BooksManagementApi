namespace BooksManagementApi.Models
{
    public class OpenLibraryBook
    {
        public string[] isbn { get; set; } = [];
        public string title { get; set; } = string.Empty;
        public string[] author_name { get; set; } = [];
        public int first_publish_year { get; set; }
        public int cover_i { get; set; }
        public int number_of_pages_median { get; set; }
        public float ratings_average { get; set; }
        public string[] language { get; set; } = [];

        public bool IsValidBook()
        {
            return isbn != null
                && author_name != null
                && isbn.Length > 0
                && author_name.Length > 0;
        }

        public bool IsEnglishBook()
        {
            return language != null && language.Contains("eng");
        }
    }
}
