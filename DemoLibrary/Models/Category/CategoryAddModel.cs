using System.ComponentModel.DataAnnotations;

namespace DemoLibrary.Models.Category
{
    public class CategoryAddModel
    {
        [Required]
        [StringLength(100, MinimumLength = 5)]
        public string Name { get; init; }
    }
}
