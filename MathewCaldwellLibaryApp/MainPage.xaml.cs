using System.Diagnostics;

namespace MathewCaldwellLibaryApp
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();

            Libary libary = new Libary("name", "address");
            libary.AddCustomer("steve", "address", "email", 010101);
            libary.AddCustomer("bob", "address", "email", 010101);

            libary.AddBook("book1", "author", 2010, new DateOnly(2026, 08, 17));
            libary.AddBook("book1", "author", 2010, new DateOnly(2026, 08, 17));
            libary.AddBook("book2", "author2", 1658, new DateOnly(2026, 09, 01));
            libary.AddBook("book2", "author2", 1658, new DateOnly(2026, 09, 01));

            foreach (Customer customer in libary.masterCustomerList)
            {
                Debug.WriteLine($"Name: {customer.name}, ID: {customer.ID}");
            }

            foreach(Book book in libary.masterBooKList)
            {
                Debug.WriteLine($"Title: {book.title}, ID: {book.ID}");
            }
        }

        
    }
}
