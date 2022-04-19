using System.ComponentModel.DataAnnotations;

namespace DemoLibrary.Data.Models
{
    public class Genre
    {
        public Genre()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
