using System.ComponentModel.DataAnnotations;

namespace DemoLibrary.Models.Author
{
    public class AuthorAddModel
    {
        [Required]
        [StringLength(80, MinimumLength = 1)]
        public string? FirstName { get; set; }

        [Required]
        [StringLength(80, MinimumLength = 2)]
        public string? LastName { get; set; }

        [Required]
        public string? CountryId { get; set; }


        public IEnumerable<AuthorCountryViewModel>? Countries { get; set; }

    }
}
