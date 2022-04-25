using DemoLibrary.Services.Book;

namespace DemoLibrary.Services.Reader
{
    public class ReaderBookService
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string AuthorFullName { get; set; }

        public string TranslatorFullName { get; set; }

        public int CreateYear { get; set; }

        public string Summary { get; set; }

        public string Series { get; set; }

        public string CoverPath { get; set; }

        public string GenreName { get; set; }

        public string CategoryName { get; set; }

        public string CountryName { get; set; }

        public int Downloads { get; set; }

        public double? Rating { get; set; }

        public ICollection<ComentServiceModel> Coments { get; set; }
        public ICollection<RatingServiceModel> Ratings { get; set; }
    }
}
