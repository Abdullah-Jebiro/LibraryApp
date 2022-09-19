using LibraryData;
using LibraryDemian;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Services;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using System.Threading.Channels;
using static Services.Services;


namespace LibraryMain
{
    internal class Program
    {
   
        static void Main(string[] args)
        {
            
            Console.WriteLine("Hello");
            AdddefualtUsers();
            if (IsUser())
            {
                Console.WriteLine($"Number of books {BooksCount()}");
                Console.WriteLine($"\r\n" +
                    "1 => Inquiry about books\r\n" +
                    "2 =>  Bring book data\r\n" +
                    "3 =>  Delete a book\r\n" +
                    "4 =>  Update book data\r\n" +
                    "or any other key to exit");

                string num =Console.ReadLine();
                switch (num)
                {
                    case "1":
                        GetInfoBooks();
                        break;
                    case "2":
                        GetBook();
                        break;
                    case "3":
                        DeleteBook();
                        break;
                    case "4":
                        UpdateBook();
                        break;
                }
            }
        }
    }
}