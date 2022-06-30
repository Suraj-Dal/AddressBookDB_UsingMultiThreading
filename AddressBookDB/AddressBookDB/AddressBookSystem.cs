using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace AddressBookDB
{
    public class AddressBookSystem
    {
        public static string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Address_Book_Service_DB;";
        public List<PersonModel> persons = new List<PersonModel>();
        public void addPerson(List<PersonModel> person)
        {
            foreach(PersonModel personModel in person)
            {
                this.createRecord(personModel);
                Console.WriteLine("Person added: " + personModel.FName);
            }
        }
        public void addPersonWithMultiThreading(List<PersonModel> person)
        {
            foreach( PersonModel personModel in person)
            {
                Task thread = new Task(() =>
                {
                    this.createRecord(personModel);
                    Console.WriteLine("Person added: " + personModel.FName);
                });
            }
        }
        public void createRecord(PersonModel model)
        {
            SqlConnection connect = new SqlConnection(connectionString);
            lock (this)
            {
                using (connect)
                {
                    connect.Open();
                    SqlCommand command = new SqlCommand("SpAddAddressBook", connect);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@First_Name", model.FName);
                    command.Parameters.AddWithValue("@Last_Name", model.LName);
                    command.Parameters.AddWithValue("@Address", model.Address);
                    command.Parameters.AddWithValue("@City", model.City);
                    command.Parameters.AddWithValue("@State", model.State);
                    command.Parameters.AddWithValue("@Zip", model.Zip);
                    command.Parameters.AddWithValue("@Phone_Number", model.Phone);
                    command.Parameters.AddWithValue("@Email", model.Email);
                    command.Parameters.AddWithValue("@Name", model.BookName);
                    command.Parameters.AddWithValue("@Type", model.BookType);
                    command.ExecuteNonQuery();
                    Console.WriteLine("Record created successfully.");
                    connect.Close();
                }
            }
        }
    }
}
