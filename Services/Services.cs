using LibraryData;
using LibraryDemian;
using Logger;
using System.Text.Json;

namespace Services
{
    public class Services
    {

        static bool BookIdCorrect(int Id)
        {
            using (var context = new DB())
            {
                if (!context.Books.Any(b => b.BookId == Id))
                {
                    FileLogger.LogUser("The Id is invalid");
                    Console.WriteLine("The Id is invalid");
                    return false;
                }
                return true;
            }
        }
        public static void AdddefualtUsers()
        {
            try
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
            catch (Exception e)
            {
                FileLogger.LogError(e.Message);
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
                if (isUser)
                {
                    FileLogger.LogUser("Login in");
                    FileLogger.UserName = UserName;

                }
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
                Console.WriteLine($"number of books : {context.Books.Sum(b => b.Count)}");
                FileLogger.LogUser("Get information Books");
            }
        }
        public static void GetBook()
        {
            Console.Write("Enter Id:");
            int id = Convert.ToInt32(Console.ReadLine());
            if (BookIdCorrect(id))
            {
                using (var context = new DB())
                {
                    var book = context.Books.SingleOrDefault(b => b.BookId == id);
                    Console.WriteLine($"Id:{book.BookId} Title:{book.Title} Count:{book.Count} Price {book.Price}");
                    FileLogger.LogUser("Get information Books", id);
                }
            }
        }
        public static void DeleteBook()
        {
            Console.Write("Enter Id:");
            int id = Convert.ToInt32(Console.ReadLine());
            if (BookIdCorrect(id))
            {
                FileLogger.LogUser("Delete Book", id);
                using (var context = new DB())
                {
                    var book = context.Books.SingleOrDefault(b => b.BookId == id);
                    context.Books.Remove(book);
                    context.SaveChanges();
                }
            }
        }
        public static void UpdateBook()
        {
            Console.Write("Enter Id:");
            int id = Convert.ToInt32(Console.ReadLine());
            if (BookIdCorrect(id))
            {
                FileLogger.LogUser("Update Book", id);
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
}