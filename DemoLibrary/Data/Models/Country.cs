using System.ComponentModel.DataAnnotations;

namespace DemoLibrary.Data.Models
{
    public class Country
    {
        public Country()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }

        [Required]
        [MaxLength(80)]
        public string Name { get; set; }
    }
}
