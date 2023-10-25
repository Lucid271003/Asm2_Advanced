using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Asm2_Advanced
{
    internal class Library
    {
        private List<Book> books;
        private List<BorrowedBook> borrowedBooks;
        public Admin admin;
        public Customer customer;
        public Library()
        {
            books = new List<Book>();
            borrowedBooks = new List<BorrowedBook>();
            admin = new Admin("minh", "271003");
            customer = new Customer("quan", "210513");
        }

        public void AddBook(Book book)
        {
            books.Add(book);
        }

        public void RemoveBook(int id)
        {
            try
            {
                Book bookToRemove = books.Find(book => book.Id == id);

                if (bookToRemove != null)
                {
                    books.Remove(bookToRemove);
                }
                else
                {
                    throw new InvalidOperationException("Book not found.");
                }
            }
            catch(InvalidOperationException ex)
            {
                Console.WriteLine("InvalidOperationException: " + ex);
            }
        }

        public List<Book> SearchBook(string keyword)
        {
            List<Book> searchResults = new List<Book>();

            searchResults = books.FindAll(book =>
                book.Name.ToLower().Contains(keyword.ToLower()) ||
                book.Author.ToLower().Contains(keyword.ToLower()) ||
                book.Genre.ToLower().Contains(keyword.ToLower())
            );
            return searchResults;
        }

        public void DisplayBook()
        {
            try
            {
                Console.WriteLine("Library Books:");
                foreach (var book in books)
                {
                    book.DisplayBook();
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine("An unexpected exception occurred: " + ex.Message);
            }
        }

        public void BorrowBook()
        {
            try
            {
                Console.Write("Enter the title of the book you want to borrow: ");
                string title = Console.ReadLine();

                if (string.IsNullOrEmpty(title))
                {
                    throw new ArgumentNullException("Book title cannot be null or empty.");
                }

                Book bookToBorrow = books.Find(book => book.Name.ToLower() == title.ToLower() && book.IsAvailable);

                if (bookToBorrow != null)
                {
                    bookToBorrow.IsAvailable = false;
                    BorrowedBook borrowedBook = new BorrowedBook(bookToBorrow.Name, bookToBorrow.Genre, bookToBorrow.Author, bookToBorrow.PublishYear, DateTime.Now);
                    borrowedBooks.Add(borrowedBook);
                    Console.WriteLine("Book borrowed successfully.");

                    SaveBorrowedBooksToFile();
                }
                else
                {
                    Console.WriteLine("The book is not available or does not exist.");
                }
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine("Input cannot be null: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unexpected exception occurred: " + ex.Message);
            }
        }

        public void ReturnBook()
        {
            try
            {
                Console.Write("Enter the title of the book you want to return: ");
                string title = Console.ReadLine();

                if (string.IsNullOrEmpty(title))
                {
                    throw new ArgumentNullException("Book title cannot be null or empty.");
                }

                if (books == null || borrowedBooks == null)
                {
                    throw new InvalidOperationException("The 'books' or 'borrowedBooks' list is null.");
                }

                BorrowedBook borrowedBook = borrowedBooks.Find(book => book.Name.ToLower() == title.ToLower());

                if (borrowedBook != null)
                {
                    Book bookToReturn = books.Find(book => book.Name == borrowedBook.Name);
                    if (bookToReturn != null)
                    {
                        bookToReturn.IsAvailable = true;
                        borrowedBooks.Remove(borrowedBook);
                        Console.WriteLine("Book returned successfully.");
                        SaveBorrowedBooksToFile();
                    }
                }
                else
                {
                    Console.WriteLine("Book not found in the borrowed list.");
                }
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine("ArgumentNullException: " + ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine("InvalidOperationException: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unexpected exception occurred: " + ex.Message);
            }
        }

        private void SaveBorrowedBooksToFile()
        {
            string filePath = @"D:\Advanced Programming\borrowed_books.txt";
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (BorrowedBook borrowedBook in borrowedBooks)
                    {
                        writer.WriteLine($"Book Title: {borrowedBook.Name}, Genre: {borrowedBook.Genre}, Author: {borrowedBook.Author}, Publish Year: {borrowedBook.PublishYear}, Borrow Date: {borrowedBook.BorrowDate}");
                    }
                }
            }
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine("Directory not found exception: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unexpected exception occurred: " + ex.Message);
            }
        }
        public void DisplayBorrowedBooksFromFile()
        {
            string filePath = @"D:\Advanced Programming\borrowed_books.txt";
            try
            {
                if (File.Exists(filePath))
                {
                    using (StreamReader reader = new StreamReader(filePath))
                    {
                        Console.WriteLine("Borrowed Books from File:");
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            Console.WriteLine(line);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("No borrowed books.");
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine("An IO exception occurred while saving borrowed books info to the file: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unexpected exception occurred: " + ex.Message);
            }
        }
    }
}



/*public void SaveBooksToFile(string fileName)
{
    using (StreamWriter writer = new StreamWriter(fileName))
    {
        foreach (var book in books)
        {
            writer.WriteLine($"{book.Id},{book.Name},{book.Author},{book.Genre},{book.PublishYear},{book.IsAvailable}");
        }
    }
}

public void LoadBooksFromFile(string fileName)
{
    books.Clear();

    if (File.Exists(fileName))
    {
        using (StreamReader reader = new StreamReader(fileName))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split(',');
                if (parts.Length == 6)
                {
                    Book book = new Book
                    {
                        Id = int.Parse(parts[0]),
                        Name = parts[1],
                        Author = parts[2],
                        Genre = parts[3],
                        PublishYear = int.Parse(parts[4]),
                        IsAvailable = bool.Parse(parts[5])
                    };
                    books.Add(book);
                }
            }
        }
    }
}*/
/*public void SaveUsersToFile(string fileName)
{
    using (StreamWriter writer = new StreamWriter(fileName))
    {
        foreach (var user in users)
        {
            writer.WriteLine($"{user.Name},{user.Password}");
        }
    }
}

public void LoadUsersFromFile(string fileName)
{
    users.Clear();

    if (File.Exists(fileName))
    {
        using (StreamReader reader = new StreamReader(fileName))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split(',');
                if (parts.Length == 2)
                {
                    users.Add(new User { Name = parts[0], Password = parts[1] });
                }
            }
        }
    }
}*/
/*public List<BorrowedBook> ReadBorrowedBooksFromFile()
        {
            List<BorrowedBook> borrowedBooks = new List<BorrowedBook>();

            string filePath = @"D:\Advanced Programming\borrowed_books.txt";

            if (File.Exists(filePath))
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(new char[] { ':', ',' }, StringSplitOptions.RemoveEmptyEntries);
                        if (parts.Length == 8)
                        {
                            BorrowedBook borrowedBook = new BorrowedBook
                            {
                                BookId = int.Parse(parts[1].Trim()),
                                BookTitle = parts[3].Trim(),
                                UserName = parts[5].Trim(),
                                BorrowDate = DateTime.Parse(parts[7].Trim())
                            };
                            borrowedBooks.Add(borrowedBook);
                        }
                    }
                }
            }

            return borrowedBooks;
        }*/
