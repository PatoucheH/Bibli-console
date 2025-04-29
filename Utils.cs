using System.Text.Json;
using System.Xml.Serialization;

namespace BibliConsole
{
    internal class Utils
    {
        public static void LoadDataJson(string fileName, out List<string[]> booksList)
        {
            booksList = new List<string[]>();

            if (File.Exists(fileName))
            {
                try
                {
                    string json = File.ReadAllText(fileName);
                    List<string[]> loadedBooks = JsonSerializer.Deserialize<List<string[]>>(json);

                    if (loadedBooks != null)
                    {
                        booksList = loadedBooks;
                        Console.WriteLine("Data successfully loaded !");
                    }
                    else
                    {
                        Console.WriteLine("No data found !");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error in the loading data {e.Message}");
                }

            }
            else
            {
                Console.WriteLine("No data found !");
            }
        }

        public static string DisplayMenu()
        {
            string choice = "";
                Console.WriteLine("Choose an option : ");
                Console.WriteLine("1. List all books");
                Console.WriteLine("2. Find all the books of an author");
                Console.WriteLine("3. Add a book");
                Console.WriteLine("4. Remove a book");
                Console.WriteLine("5. Exit the application");
                try
                {
                    choice = Console.ReadLine();

                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid input, please try again.");
                    choice = "0";
                }
            return choice;
        }

        public static void SaveDataJson(string fileName, List<string[]> booksList)
        {
            try
            {
                string json = JsonSerializer.Serialize(booksList, new JsonSerializerOptions { WriteIndented = true});
                File.WriteAllText(fileName, json);

            }catch(Exception e)
            {
                Console.WriteLine($"Erroe {e.Message}");
            }
        }

        public static string AskNoEmptyString(string message)
        {
            string input;
            do
            {
                Console.WriteLine(message);
                input = Console.ReadLine()?.Trim();
                if( string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Input cannot be empty ! ");
                }
            } while (string.IsNullOrWhiteSpace(input));
            return input;
        }
    }
}