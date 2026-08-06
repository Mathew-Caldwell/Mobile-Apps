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
    }
}
