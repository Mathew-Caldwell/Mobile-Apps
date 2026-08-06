using MetalPerformanceShaders;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace MathewCaldwellLibaryApp
{
    public class Libary
    {
        List<Book> masterBooKList = new List<Book>();
        List<Customer> masterCustomerList = new List<Customer>();
        string name = "";
        string address = "";

        public Libary(string name, string address)
        {
            this.name = name;
            this.address = address;
        }

        public void AddCustomer(string name, string address, string email, int phoneNumber)
        {
            int ID = 0;
            Customer customer = new Customer(ID, this.name, this.address, email, phoneNumber);

            masterCustomerList.Add(customer);
        }

        public void AddBook(string name, string author, int yearPublished, DateOnly dueDate, string customerWithBook, Status status)
        {
            int ID = 0;
            Book book = new Book(ID, this.name, author, yearPublished, dueDate, customerWithBook, status);

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

        public void ReturnBook(int bookID, string customerName)
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
            book.customerWithBook = "";
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
            book.status = Status.reserved;
        }
        
    }
}
