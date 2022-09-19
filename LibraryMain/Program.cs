using LibraryData;
using LibraryDemian;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;

namespace LibraryMain
{
    internal class Program
    {
        private static void AdddefualtUsers()
        {
            using (var context = new DB())
            {
                if (context.Users.Any())
                {
                    string cotents = File.ReadAllText("default.json");
                    var defualtUsers = JsonSerializer.Deserialize<List<User>>(cotents);
                    context.Users.AddRange(defualtUsers);
                    context.SaveChanges();

                }
            }
        }
        private static bool IsUser()
        {
            using (var context = new DB())
            {
                Console.Write("Enter UserName: ");
                string UserName = Console.ReadLine();
                Console.Write("Enter Password: ");
                string Password = Console.ReadLine();
                return context.Users.Any(u => u.UserName == UserName && u.Password == Password);
            }
        }
        private static int BooksCount()
        {
            using (var context = new DB())
            {
                return context.Books.Count();
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            AdddefualtUsers();         
            if (IsUser())
            {

                Console.WriteLine($"Number of books {BooksCount()}");
                int num = Convert.ToInt32(Console.ReadLine());
                switch (num)
                {
                    case 1:

                        break;
                    case 2:

                        break;
                    case 3:

                        break;
                    case 4:

                        break;
                    default:
                        break;

                }

            }
        }
    }
}