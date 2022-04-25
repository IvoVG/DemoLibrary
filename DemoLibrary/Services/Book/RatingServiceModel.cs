namespace DemoLibrary.Services.Book
{
    public class RatingServiceModel
    {
        public string ReaderId { get; set; }

        public string BookId { get; set; }

        public int Evaluation { get; set; }

        public bool IsReadBook { get; set; }
    }
}
