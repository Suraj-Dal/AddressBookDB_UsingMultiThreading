using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookDB
{
    public class PersonModel
    {
        public int PersonID { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zip { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string BookName { get; set; }
        public string BookType { get; set; }
        public PersonModel(int personID, string fName, string lName, string address, string city, string state, int zip, string phone, string email, string bookName, string bookType)
        {
            this.PersonID = personID;
            this.FName = fName;
            this.LName = lName;
            this.Address = address;
            this.City = city;
            this.State = state;
            this.Zip = zip;
            this.Phone = phone;
            this.Email = email;
            this.BookName = bookName;
            this.BookType = bookType;
        }
    }
}
