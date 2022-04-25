using System.ComponentModel.DataAnnotations;

namespace DemoLibrary.Models.Countries
{
    public class CountryAddModel
    {
        [Required]
        [StringLength(80, MinimumLength = 3)]
        public string? Name { get; set; }
    }
}
