using System.Text.Json;
using System.Xml.Serialization;

namespace BibliConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string[]> booksList = new List<string[]>();
            string fileName = "BibliConsole.json";
            string choice;

            Utils.LoadDataJson(fileName, out booksList);

            Console.WriteLine("Welcome to the Bibli Application !");
            do
            {
                choice = Utils.DisplayMenu();

                switch (choice)
                {
                    case "1":
                        Book.DisplayAllBooks(booksList);
                        break;
                    case "2":
                        Book.DiplayAllBooksByAuthor(booksList);
                        break;
                    case "3":
                        Book.AddBook(booksList);
                        break;
                    case "4":
                        Book.RemoveBook(booksList);
                        break;
                    case "5":
                        Utils.SaveDataJson(fileName, booksList);
                        break;
                }
            } while (choice != "5");
        }
    }
}
