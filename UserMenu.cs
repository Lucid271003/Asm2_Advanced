using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asm2_Advanced
{
    internal class UserMenu : IMenu
    {
        public override void DisplayMenu(Library library)
        {
            Console.Write("Enter your username: ");
            string name = Console.ReadLine();

            Console.Write("Enter your password: ");
            string password = Console.ReadLine();

            if (library.customer.Name == name && library.customer.Authenticate(password))
            {
                Console.WriteLine("Login successful.");

                while (true)
                {
                    try
                    {
                        int choice;
                        Console.WriteLine("\nUser Menu:");
                        Console.WriteLine("1. Display Books");
                        Console.WriteLine("2. Search Books");
                        Console.WriteLine("3. Borrow Book");
                        Console.WriteLine("4. Return Book");
                        Console.WriteLine("5. Display Borrowed Book");
                        Console.WriteLine("6. Return to main menu");
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
                                library.BorrowBook();
                                break;
                            case 4:
                                library.ReturnBook();
                                break;
                            case 5:
                                library.DisplayBorrowedBooksFromFile();
                                break;
                            case 6:
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
            else
            {
                Console.WriteLine("Invalid credentials. Returning to main menu.");
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
    }
}
