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
            // Update data in database........................
            bool status = addressBookRepo.UpdateTables();
            if (status)
                Console.WriteLine(" Updated Successfully");
            else
                Console.WriteLine(" Update UnSuccessfully");
        }
    }
}
