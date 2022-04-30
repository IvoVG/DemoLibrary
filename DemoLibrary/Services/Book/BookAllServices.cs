namespace DemoLibrary.Services.Book
{
    public class BookAllServices
    {
        public string? Id { get; set; }

        public string? Title { get; set; }

        public int CreateYear { get; set; }

        public DateTime Uploaded { get; set; }

        public DateTime? Improved { get; set; }

        public string? Summary { get; set; }

        public string? Series { get; set; }

        public string? GenreId { get; set; }

        public string? CategoryId { get; set; }

        public string? CountryId { get; set; }

        public string? CoverPath { get; set; }

        public string? Address { get; set; }

        public int Downloads { get; set; }
    }
}
