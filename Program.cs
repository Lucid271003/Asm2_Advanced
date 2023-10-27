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
        private static IMenu menu;
        public static void Main(string[] args)
        {
            library = new Library();

            // Add some books to the library
            library.AddBook(new Book("Harry Potter", "J.K.RowLing", "Fantasy", 1997));
            library.AddBook(new Book("Sherlock Homles", "Arthur Conan Doyle", "Detective", 1887));
            library.AddBook(new Book("The Lord of the Rings", "J.R.R.Tolkien", "Adventure", 1954));
            library.AddBook(new Book("The Alchemist", "Paulo Coelho", "Fantasy", 1988));


            Console.WriteLine("Welcome to the Library Management System!");


            while (true)
            {
                try
                {
                    int choice;
                    Console.WriteLine("\nChoose a role:");
                    Console.WriteLine("1. Admin");
                    Console.WriteLine("2. User");
                    Console.WriteLine("3. Exit");
                    Console.Write("Choice: ");
                    choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            menu = new AdminMenu();
                            menu.DisplayMenu(library);
                            break;
                        case 2:
                            menu = new UserMenu();
                            menu.DisplayMenu(library);
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
