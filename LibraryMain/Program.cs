using LibraryData;
using LibraryDemian;
using Logger;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Services;
using System.Text.Json;
using System.Threading.Channels;
using static Services.Services;


namespace LibraryMain
{
    internal class Program
    {
        static void Main(string[] args)
        {

            AddDefualtUsers();
            if (IsUser())
            {
                Console.WriteLine($"\nNumber of books {BooksCount()}");

                string? num = String.Empty;
                do
                {
                    Console.WriteLine($"\r\n" +
                                       "1 =>  Inquiry about books\r\n" +
                                       "2 =>  Bring book data\r\n" +
                                       "3 =>  Delete a book\r\n" +
                                       "4 =>  Update book data\r\n" +
                                       "5 =>  exit");

                    num = Console.ReadLine();
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
                        case "5":
                            break;

                    }
                } while (!(num=="5"));
            }
        }
    }
}