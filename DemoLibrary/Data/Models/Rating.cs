using System.ComponentModel.DataAnnotations;

namespace DemoLibrary.Data.Models
{
    public class Rating
    {
        public Rating()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }

        [Required]
        [Range(1, 10)]
        public int Evaluation { get; set; }

        public bool IsReadBook { get; set; }

        [Required]
        public string ReaderId { get; set; }

        [Required]
        public string BookId { get; set; }
    }
}
