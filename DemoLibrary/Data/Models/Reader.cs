using System.ComponentModel.DataAnnotations;

namespace DemoLibrary.Data.Models
{
    public class Reader
    {
        public Reader()
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

        public ICollection<ReaderBook> Books { get; init; } = new List<ReaderBook>();

        public ICollection<Comment> Coments { get; init; } = new List<Comment>();

        public ICollection<Rating> Ratings { get; init; } = new List<Rating>();
    }
}
