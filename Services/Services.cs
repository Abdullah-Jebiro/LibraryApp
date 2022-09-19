using LibraryData;
using LibraryDemian;
using System.Text.Json;

namespace Services
{
    public class Services
    {
        public static void AdddefualtUsers()
        {
            using (var context = new DB())
            {
                if (!context.Users.Any())
                {
                    string cotents = File.ReadAllText("default.json");
                    var defualtUsers = JsonSerializer.Deserialize<List<User>>(cotents);
                    context.Users.AddRange(defualtUsers);
                    context.SaveChanges();

                }
            }
        }
        public static bool IsUser()
        {
            using (var context = new DB())
            {
                Console.Write("Enter UserName:");
                string UserName = Console.ReadLine().Trim();
                Console.Write("Enter Password:");
                string Password = Console.ReadLine().Trim();
                bool isUser = context.Users.Any(u => u.UserName == UserName && u.Password == Password);
                return isUser;
            }
        }
        public static int BooksCount()
        {
            using (var context = new DB())
            {
                return context.Books.Count();
            }
        }
        public static void GetInfoBooks()
        {
            using (var context = new DB())
            {
                var books = context.Books.Select(b => new { b.BookId, b.Title, b.Count }).ToList(); ;
                foreach (var book in books)
                {
                    Console.WriteLine($"Id:{book.BookId} Title:{book.Title} Count:{book.Count}");
                }
                Console.WriteLine(context.Books.Sum(b => b.Count));
            }
        }
        public static void GetBook()
        {
            Console.Write("Enter Id:");
            int id = Convert.ToInt32(Console.ReadLine());
            using (var context = new DB())
            {
                var book = context.Books.SingleOrDefault(b => b.BookId == id);
                Console.WriteLine($"Id:{book.BookId} Title:{book.Title} Count:{book.Count} Price {book.Price}");
            }
        }
        public static void DeleteBook()
        {
            Console.Write("Enter Id:");
            int id = Convert.ToInt32(Console.ReadLine());
            using (var context = new DB())
            {
                var book = context.Books.SingleOrDefault(b => b.BookId == id);
                context.Books.Remove(book);
                context.SaveChanges();
            }
        }
        public static void UpdateBook()
        {
            Console.Write("Enter Id:");
            int id = Convert.ToInt32(Console.ReadLine());
            using (var context = new DB())
            {
                var book = context.Books.SingleOrDefault(b => b.BookId == id);
                Console.Write("Enter Title:");
                book.Title = Console.ReadLine();
                Console.Write("Enter Price:");
                book.Price = Convert.ToInt32(Console.ReadLine());
                context.SaveChanges();
            }
        }
    }
}