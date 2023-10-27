using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asm2_Advanced
{
    internal class AdminMenu : IMenu
    {
        public override void DisplayMenu(Library library)
        {
            Console.Write("Enter your username: ");
            string name = Console.ReadLine();

            Console.Write("Enter your password: ");
            string password = Console.ReadLine();

            if (library.admin.Name == name && library.admin.Authenticate(password))
            {
                Console.WriteLine("Login successful.");

                while (true)
                {
                    try
                    {
                        int choice;
                        Console.WriteLine("\nAdmin Menu:");
                        Console.WriteLine("1. Display Books");
                        Console.WriteLine("2. Search Books");
                        Console.WriteLine("3. Add Book");
                        Console.WriteLine("4. Remove Book");
                        Console.WriteLine("5. Return to main menu");
                        Console.Write("Choice: ");
                        choice = int.Parse(Console.ReadLine());

                        switch (choice)
                        {
                            case 1:
                                library.DisplayBook();
                                break;
                            case 2:
                                SearchBooks(library);
                                break;
                            case 3:
                                AddBook(library);
                                break;
                            case 4:
                                RemoveBook(library);
                                break;
                            case 5:
                                return;
                            default:
                                Console.WriteLine("Invalid choice. Please try again.");
                                break;
                        }
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine("FormatException: " + ex.Message);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Exception: " + ex.Message);
                    }
                }
            }
        }
        private void SearchBooks(Library library)
        {
            try
            {
                Console.Write("Enter a keyword to search for: ");
                string keyword = Console.ReadLine();

                if (string.IsNullOrEmpty(keyword))
                {
                    throw new ArgumentNullException("Keyword cannot be null or empty.");
                }

                List<Book> searchResults = library.SearchBook(keyword);

                if (searchResults.Count > 0)
                {
                    Console.WriteLine("Search results:");
                    foreach (var book in searchResults)
                    {
                        Console.WriteLine($"ID: {book.Id}, Title: {book.Name}, Author: {book.Author}, Genre: {book.Genre}, Publish Year: {book.PublishYear}, Available: {book.IsAvailable}");
                    }
                }
                else
                {
                    Console.WriteLine("No books found matching the search criteria.");
                }
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine("ArgumentNullException: " + ex.Message);
            }
        }
        private static void AddBook(Library library)
        {
            
            try
            {
                Console.Write("Enter the title of the book: ");
                string title = Console.ReadLine();

                if (string.IsNullOrEmpty(title))
                {
                    throw new ArgumentNullException("Title cannot be null or empty.");
                }
                foreach (char c in title)
                {
                    if (char.IsDigit(c))
                    {
                        throw new FormatException("Book name cannot contain numbers.");
                    }
                }

                Console.Write("Enter the author of the book: ");
                string author = Console.ReadLine();

                if (string.IsNullOrEmpty(author))
                {
                    throw new ArgumentNullException("Author cannot be null or empty.");
                }
                foreach (char c in author)
                {
                    if (char.IsDigit(c))
                    {
                        throw new FormatException("Author cannot contain numbers.");
                    }
                }

                Console.Write("Enter the genre of the book: ");
                string genre = Console.ReadLine();

                if (string.IsNullOrEmpty(genre))
                {
                    throw new ArgumentNullException("Genre cannot be null or empty.");
                }
                foreach (char c in genre)
                {
                    if (char.IsDigit(c))
                    {
                        throw new FormatException("Genre cannot contain numbers.");
                    }
                }

                Console.Write("Enter the publish year of the book: ");
                if (int.TryParse(Console.ReadLine(), out int publishYear))
                {
                    if (publishYear < 1000 || publishYear > 9999)
                    {
                        throw new FormatException("Publish year must be input 4 numbers.");
                    }
                }
                else
                {
                    throw new FormatException("Invalid input for publish year.");
                }

                library.AddBook(new Book(title, genre, author, publishYear));
                Console.WriteLine("Book added successfully.");
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine("ArgumentNullException: " + ex.Message);
            }
            catch (FormatException ex)
            {
                Console.WriteLine("FormatException: " + ex.Message);
            }
        }
        private static void RemoveBook(Library library)
        {
            try
            {
                Console.Write("Enter the ID of the book you want to delete: ");
                if (int.TryParse(Console.ReadLine(), out int bookId))
                {
                    library.RemoveBook(bookId);
                    Console.WriteLine("Book removed successfully.");
                }
                else
                {
                    throw new FormatException("Invalid input. Please enter a valid book ID.");
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine("FormatException: " + ex.Message);
            }
        }
    }
}
