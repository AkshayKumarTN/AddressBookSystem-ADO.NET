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
            addressBookRepo.CountOfContacts();
           
        }
    }
}
