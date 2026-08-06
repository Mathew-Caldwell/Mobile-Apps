using System.Diagnostics;

namespace MathewCaldwellLibaryApp
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();

            //create new libary
            Libary libary = new Libary("name", "address");


            //add customers
            libary.AddCustomer("steve", "address", "email", 010101);
            libary.AddCustomer("bob", "address", "email", 010101);


            //add books
            libary.AddBook("book1", "author", 2010, new DateOnly(2026, 08, 17));
            libary.AddBook("book1", "author", 2010, new DateOnly(2026, 08, 17));
            libary.AddBook("book2", "author2", 1658, new DateOnly(2026, 09, 01));
            libary.AddBook("book2", "author2", 1658, new DateOnly(2026, 09, 01));


            //check each customer has unique id
            foreach (Customer customer in libary.masterCustomerList)
            {
                Debug.WriteLine($"Name: {customer.name}, ID: {customer.ID}");
            }

            Debug.WriteLine("-----------------------------------------------");


            //check each book has unique id
            foreach(Book book in libary.masterBooKList)
            {
                Debug.WriteLine($"Title: {book.title}, ID: {book.ID}");
            }

            Debug.WriteLine("-----------------------------------------------");


            //testing checking books out
            libary.CheckOutBook(2, "steve");
            libary.CheckOutBook(3, "steve");
            libary.CheckOutBook(1, "bob");

            foreach(Book book in libary.masterBooKList)
            {
                Debug.WriteLine($"Book: {book.title}, Status: {book.status}, Customer with book: {book.customerWithBook}");
            }

            Debug.WriteLine("-----------------------------------------------");


            //testing returning books
            libary.ReturnBook(3);

            foreach (Book book in libary.masterBooKList)
            {
                Debug.WriteLine($"Book: {book.title}, Status: {book.status}, Customer with book: {book.customerWithBook}");
            }

            Debug.WriteLine("-----------------------------------------------");


            //testing reserving books
            libary.ReserveBook(4, "bob");

            foreach (Book book in libary.masterBooKList)
            {
                Debug.WriteLine($"Book: {book.title}, Status: {book.status}, Customer with book: {book.customerWithBook}");
            }

            Debug.WriteLine("-----------------------------------------------");


            //testing reporting book lost
            libary.ReportBookLost(4);

            foreach (Book book in libary.masterBooKList)
            {
                Debug.WriteLine($"Book: {book.title}, Status: {book.status}, Customer with book: {book.customerWithBook}");
            }
        }

        
    }
}
