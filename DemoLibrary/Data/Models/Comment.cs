using System.ComponentModel.DataAnnotations;

namespace DemoLibrary.Data.Models
{
    public class Comment
    {
        public Comment()
        {
            this.Id=Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        [Required]
        [MaxLength(500)]
        public string Description { get; set; }

        public DateTime Time { get; set; }

        [Required]
        public string ReaderId { get; set; }

        [Required]
        public string BookId { get; set; }
    }
}
