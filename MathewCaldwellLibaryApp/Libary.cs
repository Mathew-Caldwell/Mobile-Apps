using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace MathewCaldwellLibaryApp
{
    public class Libary
    {
        public List<Book> masterBooKList = new List<Book>();
        public List<Customer> masterCustomerList = new List<Customer>();
        string name = "";
        string address = "";

        public Libary(string name, string address)
        {
            this.name = name;
            this.address = address;
        }

        public void AddCustomer(string customerName, string customerAddress, string email, int phoneNumber)
        {
            int ID = masterCustomerList.Count + 1;
            Customer customer = new Customer(ID, customerName, customerAddress, email, phoneNumber);

            masterCustomerList.Add(customer);
        }

        public void AddBook(string bookName, string author, int yearPublished, DateOnly dueDate)
        {
            int ID = masterBooKList.Count + 1;
            Book book = new Book(ID, bookName, author, yearPublished, dueDate, "Libary", Status.available);

            masterBooKList.Add(book);
        }

        public void CheckOutBook(int bookID, string customerName)
        {
            Book book = masterBooKList[0];
            for(int i = 0; i < masterBooKList.Count; i++)
            {
                if(masterBooKList[i].ID == bookID)
                {
                    book = masterBooKList[i];
                }
            }
            book.status = Status.checkedOut;
            book.customerWithBook = customerName;
        }

        public void ReturnBook(int bookID)
        {
            Book book = masterBooKList[0];
            for (int i = 0; i < masterBooKList.Count; i++)
            {
                if (masterBooKList[i].ID == bookID)
                {
                    book = masterBooKList[i];
                }
            }
            book.status = Status.available;
            book.customerWithBook = "Libary";
        }

        public void ReserveBook(int bookID, string customerName)
        {
            Book book = masterBooKList[0];
            for (int i = 0; i < masterBooKList.Count; i++)
            {
                if (masterBooKList[i].ID == bookID)
                {
                    book = masterBooKList[i];
                }
            }
            book.status = Status.reserved;
            book.customerWithBook = customerName;
        }

        public void ReportBookLost(int bookID)
        {
            Book book = masterBooKList[0];
            for (int i = 0; i < masterBooKList.Count; i++)
            {
                if (masterBooKList[i].ID == bookID)
                {
                    book = masterBooKList[i];
                }
            }
            book.status = Status.lost;
        }
        
    }
}
