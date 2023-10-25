using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Asm2_Advanced
{
    internal class Menu : IMenu
    {
        public int Mainmenu()
        {
            int choice;
            Console.WriteLine("\nChoose a role:");
            Console.WriteLine("1. Admin");
            Console.WriteLine("2. User");
            Console.WriteLine("3. Exit");
            Console.Write("Choice: ");
            choice = int.Parse(Console.ReadLine());
            return choice;
        }
        public int AdminMenu()
        {
            int choice;
            Console.WriteLine("\nAdmin Menu:");
            Console.WriteLine("1. Display Books");
            Console.WriteLine("2. Search Books");
            Console.WriteLine("3. Add Book");
            Console.WriteLine("4. Remove Book");
            Console.WriteLine("6. Return to main menu");
            Console.Write("Choice: ");
            choice = int.Parse(Console.ReadLine());
            return choice;
        }
        public int UserMenu()
        {
            int choice;
            Console.WriteLine("\nUser Menu:");
            Console.WriteLine("1. Display Books");
            Console.WriteLine("2. Search Books");
            Console.WriteLine("3. Borrow Book");
            Console.WriteLine("4. Return Book");
            Console.WriteLine("5. Display Borrowed Books");
            Console.WriteLine("6. Return to main menu");
            Console.Write("Choice: ");
            choice = int.Parse(Console.ReadLine());
            return choice;
        }
    }
}
