using System.ComponentModel.DataAnnotations;

namespace DemoLibrary.Models.Worker
{
    public class WorkerAddModel
    {
        [Required]
        [StringLength(80, MinimumLength = 2)]
        public string Name { get; set; }
    }
}
