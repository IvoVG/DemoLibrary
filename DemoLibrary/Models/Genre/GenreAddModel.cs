using System.ComponentModel.DataAnnotations;

namespace DemoLibrary.Models.Genre
{
    public class GenreAddModel
    {
        [Required]
        [StringLength(100, MinimumLength = 5)]
        public string Name { get; init; }
    }
}
