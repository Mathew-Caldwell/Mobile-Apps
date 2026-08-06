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

        /// <summary>
        /// Add a customer and all their detail to libary customer list
        /// </summary>
        /// <param name="customerName"></param>
        /// <param name="customerAddress"></param>
        /// <param name="email"></param>
        /// <param name="phoneNumber"></param>
        public void AddCustomer(string customerName, string customerAddress, string email, int phoneNumber)
        {
            int ID = masterCustomerList.Count + 1;
            Customer customer = new Customer(ID, customerName, customerAddress, email, phoneNumber);

            masterCustomerList.Add(customer);
        }

        /// <summary>
        /// Add a new book and all its details to libary book list
        /// </summary>
        /// <param name="bookName"></param>
        /// <param name="author"></param>
        /// <param name="yearPublished"></param>
        /// <param name="dueDate"></param>
        public void AddBook(string bookName, string author, int yearPublished, DateOnly dueDate)
        {
            int ID = masterBooKList.Count + 1;
            Book book = new Book(ID, bookName, author, yearPublished, dueDate, "Libary", Status.available);

            masterBooKList.Add(book);
        }

        /// <summary>
        /// Changes books status to checkedOut and records which customer has the book
        /// </summary>
        /// <param name="bookID"></param>
        /// <param name="customerName"></param>
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

        /// <summary>
        /// Sets book status to available and reverts who has possesion back to the libary
        /// </summary>
        /// <param name="bookID"></param>
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
            book.customerWithBook = this.name;
        }

        /// <summary>
        /// Allows customer to reserve a book
        /// </summary>
        /// <param name="bookID"></param>
        /// <param name="customerName"></param>
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

        /// <summary>
        /// Allows customer to report a book lost 
        /// </summary>
        /// <param name="bookID"></param>
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
