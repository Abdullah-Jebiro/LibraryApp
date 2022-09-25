using System.ComponentModel.DataAnnotations;

namespace LibraryDemian
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; } = null!;
        public int Price { get; set; }
        public int Count { get; set; }
    }
}