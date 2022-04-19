using System.ComponentModel.DataAnnotations;

namespace DemoLibrary.Data.Models
{
    public class Author
    {
        public Author()
        {
            this.Id= Guid.NewGuid().ToString();        }

        public string Id { get; set; }

        [Required]
        [MaxLength(80)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(80)]
        public string LastName { get; set; }

        [Required]
        public string CountryId { get; set; }

        public Country Country { get; set; }

        public ICollection<Book> Books { get; init; } = new List<Book>();
    }
}
