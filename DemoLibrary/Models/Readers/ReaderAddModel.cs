using System.ComponentModel.DataAnnotations;

namespace DemoLibrary.Models.Readers
{
    public class ReaderAddModel
    {
        [Required]
        [StringLength(80, MinimumLength = 2)]
        public string Name { get; set; }
    }
}
