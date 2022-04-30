using DemoLibrary.Data.Models;

namespace DemoLibrary.Services.Book
{
    public class BookDetailsServiceModel
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string AuthorFullName { get; set; }

        public string TranslatorFullName { get; set; }

        public int? CreateYear { get; set; }

        public DateTime Uploaded { get; set; }

        public DateTime? Improved { get; set; }

        public string Summary { get; set; }

        public string Series { get; set; }

        public Genre Genre { get; set; }

        public Category Category { get; set; }

        public Country Country { get; set; }

        public string CoverPath { get; set; }

        public string Address { get; set; }

        public int Downloads { get; set; }

        public double? Rating { get; set; }

        public ICollection<ComentServiceModel> Coments { get; set; }
        public ICollection<RatingServiceModel> Ratings { get; set; }
    }
}
