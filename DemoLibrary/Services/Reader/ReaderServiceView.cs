using DemoLibrary.Data.Models;

namespace DemoLibrary.Services.Reader
{
    public class ReaderServiceView
    {
        public string ReaderId { get; set; }

        public string Name { get; set; }

        public string UserId { get; set; }

        public string BookId { get; set; }

        public ReaderBookService Book { get; set; }

        public ICollection<ReaderBookService> Books { get; set; }

        public ICollection<Comment> Coments { get; set; }

        public ICollection<Rating> Ratings { get; set; }
    }
}
