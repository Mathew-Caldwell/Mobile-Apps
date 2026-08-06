using System;
using System.Collections.Generic;
using System.Text;

namespace MathewCaldwellLibaryApp
{
    public class Book
    {
        public int ID;
        public string title = "";
        public string author = "";
        public int yearPublished;
        public DateOnly dueDate;
        public string customerWithBook = "";
        public Status status;

        public Book(int ID, string title, string author, int yearPublished, DateOnly dueDate, string customerWithBook, Status status)
        {
            this.ID = ID;
            this.title = title;
            this.author = author;
            this.yearPublished = yearPublished;
            this.dueDate = dueDate;
            this.customerWithBook = customerWithBook;
            this.status = status;
        }
    }
}
