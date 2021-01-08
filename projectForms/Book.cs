using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectForms
{
    class Book
    {

        int bookID;
        string bookName;
        int bookEdition;
        string bookAuthor;
        int bookpages;
        string description;
        string bookType;

        public int BookID { get => bookID; set => bookID = value; }
        public string BookName { get => bookName; set => bookName = value; }
        public int BookEdition { get => bookEdition; set => bookEdition = value; }
        public string BookAuthor { get => bookAuthor; set => bookAuthor = value; }
        public int Bookpages { get => bookpages; set => bookpages = value; }
        public string Description { get => description; set => description = value; }
        public string BookType { get => bookType; set => bookType = value; }

        public Book(int bookID, string bookName, int bookEdition, string bookAuthor, int bookPages, string description,
           string bookType)
        {
            BookID = bookID;
            BookName = bookName;
            BookEdition = bookEdition;
            Bookpages = bookPages;
            Description = description;
            BookType = bookType;

        }
    }
}