namespace hoang_quang_truong_Ph53866.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public int CategoryId { get; set; }
        public DateTime PublishYear { get; set; }

        public Author Author { get; set; }
        public Category Category { get; set; }
    }
}
