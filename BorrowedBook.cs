using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asm2_Advanced
{
    internal class BorrowedBook : Book
    {
        private DateTime borrowDate;
        public DateTime BorrowDate
        {
            get { return borrowDate; }
            set { borrowDate = value; }
        }
        public BorrowedBook(string name, string genre, string author, int publishYear, DateTime borrowDate) : base(name, genre, author, publishYear)
        {
            BorrowDate = borrowDate;
        }
        //public override void DisplayBook()
        //{
        //    Console.WriteLine(base.ToString() + $"Borow Date: {BorrowDate}");
        //}
    }
}
