using AddressBookDB;
namespace TestAddressBook
{
    public class Tests
    {
        [Test]
        public void GivenListOfPersons_AddIntoDatabase_TestTimeRequiredToAdd()
        {
            List<PersonModel> model = new List<PersonModel>();
            model.Add(new PersonModel(personID: 1, fName: "Akash", lName: "D", address: "Pune", city: "pune", state: "Maharashtra", zip: 412213, phone: "9867543672", email: "akash@gmail.com", bookName: "Family", bookType: "Family"));
            model.Add(new PersonModel(personID: 1, fName: "Ashish", lName: "C", address: "Bhor", city: "pune", state: "Maharashtra", zip: 412215, phone: "6433826486", email: "ashish@gmail.com", bookName: "Friend", bookType: "Friend"));
            model.Add(new PersonModel(personID: 1, fName: "Amit", lName: "P", address: "Parvati", city: "pune", state: "Maharashtra", zip: 411037, phone: "9867628854", email: "amit@gmail.com", bookName: "Friend", bookType: "Friend"));
            model.Add(new PersonModel(personID: 1, fName: "Bharat", lName: "G", address: "Parvati", city: "pune", state: "Maharashtra", zip: 411037, phone: "9133287672", email: "bharat@gmail.com", bookName: "Friend", bookType: "Friend"));
            model.Add(new PersonModel(personID: 1, fName: "Nitin", lName: "K", address: "Ambegaon", city: "pune", state: "Maharashtra", zip: 411047, phone: "9864326572", email: "nitin@gmail.com", bookName: "Friend", bookType: "Friend"));
            AddressBookSystem system = new AddressBookSystem();
            DateTime start = DateTime.Now;
            system.addPerson(model);
            DateTime end = DateTime.Now;
            Console.WriteLine("Time required to add all persons is: "+ (end - start));

            DateTime startTime = DateTime.Now;
            system.addPersonWithMultiThreading(model);
            DateTime dateTime = DateTime.Now;
            Console.WriteLine("Time Required to add all persons using multithreading is: "+ (dateTime - startTime));
        }
    }
}