using System;
using System.Collections.Generic;
using System.Text;

namespace MathewCaldwellLibaryApp
{
    public class Customer
    {
        public int ID;
        public string name = "";
        public string address = "";
        public string email = "";
        public int phoneNumber;

        public Customer(int ID, string name, string address, string email, int phoneNumber)
        {
            this.ID = ID;
            this.name = name;
            this.address = address;
            this.email = email;
            this.phoneNumber = phoneNumber;
        }
    }
}
