using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Asm2_Advanced
{
    internal class Program
    {
        private static Library library;
        public static void Main(string[] args)
        {
            library = new Library();

            // Add some books to the library
            library.AddBook(new Book("Harry Potter", "J.K.RowLing", "Fantasy", 1997));
            library.AddBook(new Book("Sherlock Homles", "Arthur Conan Doyle", "Detective", 1887));
            library.AddBook(new Book("The Lord of the Rings", "J.R.R.Tolkien", "Adventure", 1954));
            library.AddBook(new Book("The Alchemist", "Paulo Coelho", "Fantasy", 1988));

            IMenu mainMenu = new Menu();

            Console.WriteLine("Welcome to the Library Management System!");
            
            while (true)
            {
                try
                {
                    int roleChoice = mainMenu.MainMenu();
                    switch (roleChoice)
                    {
                        case 1:
                            AdminMenu();
                            break;
                        case 2:
                            UserMenu();
                            break;
                        case 3:
                            Console.WriteLine("Exiting the Library Management System. Goodbye!");
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
        
        private static void AdminMenu()
        {
            IMenu adminMenu = new Menu();

            Console.Write("Enter your username: ");
            string name = Console.ReadLine();

            Console.Write("Enter your password: ");
            string password = Console.ReadLine();

            if (library.admin.Name == name && library.admin.Authenticate(password))
            {
                Console.WriteLine("Login successful.");

                while (true)
                {
                    try {
                        int adminChoice = adminMenu.AdminMenu();
                        switch (adminChoice)
                        {
                            case 1:
                                library.DisplayBook();
                                break;
                            case 2:
                                SearchBooks();
                                break;
                            case 3:
                                AddBook();
                                break;
                            case 4:
                                RemoveBook();
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
            else {
                    Console.WriteLine("Invalid credentials. Returning to main menu.");
                }
        }

        private static void UserMenu()
        {
            IMenu userMenu = new Menu();

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
                        int userChoice = userMenu.UserMenu();
                        switch (userChoice)
                        {
                            case 1:
                                library.DisplayBook();
                                break;
                            case 2:
                                SearchBooks();

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
        private static void AddBook()
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

        private static void RemoveBook()
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

        private static void SearchBooks()
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

/*private static User LoginUser()
        {
            Console.Write("Enter your username: ");
            string name = Console.ReadLine();

            Console.Write("Enter your password: ");
            string password = Console.ReadLine();

            return new User { Name = name, Password = password };
        }

        private static User RegisterUser()
        {
            Console.Write("Enter a username for registration: ");
            string name = Console.ReadLine();

            Console.Write("Enter a password: ");
            string password = Console.ReadLine();

            return new User { Name = name, Password = password };
        }*/
