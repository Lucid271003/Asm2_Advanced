using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asm2_Advanced
{
    internal class BorrowedBook : IBookBase
    {
        private int bookId;
        private string bookTitle;
        private string userName;
        private DateTime borrowDate;
        public int BookId
        {
            get { return bookId; }
            set { bookId = value; }
        }
        public string BookTitle
        {
            get { return bookTitle; }
            set { bookTitle = value; }
        }
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        public DateTime BorrowDate
        {
            get { return borrowDate; }
            set { borrowDate = value; }
        }
        public void DisplayBook()
        {
            Console.WriteLine($"Book ID: {BookId}, Book Title: {BookTitle}, User: {UserName}, Borrow Date: {BorrowDate}");
        }
    }
}
