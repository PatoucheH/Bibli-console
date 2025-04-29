using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliConsole
{
    internal class Book
    {
        public required string Title { get; set; }
        public required string Author { get; set; }
        public int PublicationYear { get; set; }

        public Book(string title, string author, int publicationYear)
        {
            Title = title;
            Author = author;
            PublicationYear = publicationYear;
        }

        public static void DisplayAllBooks(List<string[]> bookList)
        {

            foreach (var book in bookList)
            {
                Console.WriteLine($"Title: {book[0]}\nAuthor: {book[1]}\nPublication Year: {book[2]}");
                Console.WriteLine("---------------");
            }

        }

        public static void DiplayAllBooksByAuthor(List<string[]> booksList)
        { 
            string[] authorList = booksList.Select(b => b[1].ToLower()).Distinct().ToArray();
            string author = "";

            author = Utils.AskNoEmptyString("Enter the author name: ");

            var booksByAuthor = booksList.Where(b => b[1].Equals(author, StringComparison.OrdinalIgnoreCase)).ToList();
            if(booksByAuthor != null)
            {
                foreach(var book in booksByAuthor)
                {
                    Console.WriteLine($"Title: {book[0]}\nAuthor: {book[1]}\nPublication Year: {book[2]}");
                    Console.WriteLine("---------------");
                }
            }
        }

        public static void AddBook(List<string[]> booksList)
        {
            string title = "", authorName = "";
            //do
            //{
            //    Console.WriteLine("Enter the title of the book: ");
            //    title = Console.ReadLine()?.Trim();
            //    if (string.IsNullOrEmpty(title)) ;
            //    {
            //        Console.WriteLine("Title cannot be empty ! ");
            //    }
            //} while (string.IsNullOrWhiteSpace(title));
            //do
            //{
            //    Console.WriteLine("Enter the author of the book: ");
            //    authorName = Console.ReadLine();
            //    if (string.IsNullOrEmpty(title)) ;
            //    {
            //        Console.WriteLine("Author's name cannot be empty ! ");
            //    }

            //}
            //while (string.IsNullOrWhiteSpace(authorName));

            title = Utils.AskNoEmptyString("Enter the title of the book : ");
            authorName = Utils.AskNoEmptyString("Enter the author of the book : ");

            Console.WriteLine("Enter the publication year of the book: ");
            int publicationYear;
            while (!int.TryParse(Console.ReadLine(), out publicationYear))
            {
                Console.WriteLine("Invalid input, please enter a valid year.");
            }

            string[] newBook = { title, authorName, publicationYear.ToString() };
            booksList.Add(newBook);
            Console.WriteLine($"Book '{title}' by {authorName} added succesfully.");
            Console.WriteLine("---------------");
        }

        public static void RemoveBook(List<string[]> booksList)
        { 
            string titleToRemove;
            //do
            //{
            //    Console.WriteLine("Enter the title of the book to remover: ");
            //    titleToRemove = Console.ReadLine();
            //} while (!booksList.Any(b => b[0].Equals(titleToRemove, StringComparison.OrdinalIgnoreCase)));
            titleToRemove = Utils.AskNoEmptyString("Enter the title of the book to remove : ");

            var bookToRemove = booksList.FirstOrDefault(b => b[0].Equals(titleToRemove, StringComparison.OrdinalIgnoreCase));
            
            if(bookToRemove != null)
            {
                booksList.Remove(bookToRemove);
                Console.WriteLine($"Book '{titleToRemove}' removed succesfully.");
                Console.WriteLine("---------------");
            }
            else
            {
                Console.WriteLine($"Book '{titleToRemove}' not found.");
                Console.WriteLine("---------------");
            }
        }

    }
}
