using System.ComponentModel.DataAnnotations;

namespace DemoLibrary.Data.Models
{
    public class Worker
    {
        public Worker()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        [Required]
        [MaxLength(80)]
        public string Name { get; set; }

        [Required]
        public string UserId { get; set; }

        public User User { get; set; }

        public ICollection<Book> Books { get; init; } = new List<Book>();
    }
}
