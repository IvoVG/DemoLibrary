using System.ComponentModel.DataAnnotations;

namespace DemoLibrary.Models.Book
{
    public class AddBookModel
    {
        [Required]
        [StringLength(250, MinimumLength = 1)]
        public string? Title { get; init; }

        public string? AuthorId { get; init; }

        [Required]
        public string? AuthorFirstName { get; init; }

        [Required]
        public string? AuthorLastName { get; init; }

        public string? TranslatorId { get; init; }

        [Required]
        public string? TranslatorFirstName { get; init; }

        [Required]
        public string? TranslatorLastName { get;init; }

        public int CreateYear { get; init; }

        public DateTime Uploaded { get;init; }

        public DateTime? Improved { get; init; }


        [StringLength(1000, MinimumLength = 20)]
        public string? Summary { get; init; }

        [MaxLength(250)]
        public string? Series { get; init; }

        public string? GenreId { get; init; }

        public string? CategoryId { get; init; }

        public string? CountryId { get; init; }

        [Required(ErrorMessage = "Please select a file.")]
        [DataType(DataType.Upload)]
        [MaxFileSize(5 * 1024 * 1024)]
        [AllowedExtensions(new string[] { ".jpg" })]
        public IFormFile? CoverUrl { get; init; }


        [Required(ErrorMessage = "Please select a file.")]
        [DataType(DataType.Upload)]
        [MaxFileSize(5 * 1024 * 1024)]
        [AllowedExtensions(new string[] { ".epub" })]
        public IFormFile? Address { get; init; }

        public IEnumerable<BookGenreViewModel>? Genres { get; set; }

        public IEnumerable<BookCategoryViewModel>? Categories { get; set; }

        public IEnumerable<BookCountryViewModel>? Countries { get; set; }
    }
}
