namespace DemoLibrary.Data.Models
{
    public class ReaderBook
    {
        public string ReaderId { get; set; }

        public Reader Reader { get; set; }

        public string BookId { get; set; }

        public Book Book { get; set; }
    }
}
