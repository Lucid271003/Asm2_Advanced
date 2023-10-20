﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asm2_Advanced
{
    internal class Book : IBookBase
    {
        private static int idCounter = 1;

        private int id;
        private string name;
        private string genre;
        private string author;
        private int publishYear;
        private bool isAvailable = true;

        public int Id
        {
            get { return id; }
            private set { id = value; }

        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Genre
        {
            get { return genre; }
            set { genre = value; }
        }
        public string Author
        {
            get { return author; }
            set { author = value; }
        }
        public int PublishYear
        {
            get { return publishYear; }
            set {  publishYear = value; }
        }
        public bool IsAvailable 
        {
            get { return isAvailable; }
            set { isAvailable = value; }
        }
        public Book()
        {
            Id = idCounter++;
        }
        public Book(string name, string genre, string author, int publishYear)
        {
            Name = name;
            Genre = genre;
            Author = author;
            PublishYear = publishYear;
        }

        public void DisplayBook()
        {
            Console.WriteLine($"ID: {Id}, Name: {Name}, Author: {Author}, Genre: {Genre}, Publish Year: {PublishYear}, Available: {IsAvailable}");
        }
    }
}
