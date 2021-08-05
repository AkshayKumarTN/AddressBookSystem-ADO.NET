using System;

namespace AddressBookSystemService
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" AddressBook System Service ");
            Console.WriteLine("***********************************************************************");
            AddressBookRepo addressBookRepo = new AddressBookRepo();
            // Retriving Count of Contact By State Or City........................
            Contact contact = new Contact();
            contact.firstName = "Rahul";
            contact.lastName = "M";
            contact.address = "J-Nagar";
            contact.city = "Mumbai";
            contact.state = "Maharashtra";
            contact.zip = 632201;
            contact.phoneNumber = 789543210;
            contact.emailId = "Rahuly@gmail.com";
            contact.contactType = "Professional";
            contact.addressBookName = "Office";
            addressBookRepo.AddContact(contact);

        }
    }
}
