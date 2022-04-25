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

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public IEnumerable<AuthorCountryViewModel> Countries { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    }
}
