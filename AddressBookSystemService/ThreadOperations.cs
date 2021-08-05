using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading;

namespace AddressBookSystemService
{
    public class ThreadOperations
    {
        public static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AddressBookSystem;Integrated Security=True";
        SqlConnection sqlconnection = new SqlConnection(connectionString);

        // Method to Add New Contact To DataBase .................
        public bool AddContact(Contact contact)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (this.sqlconnection)
                {
                    SqlCommand sqlCommand = new SqlCommand("spAddContact", this.sqlconnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@FirstName", contact.firstName);
                    sqlCommand.Parameters.AddWithValue("@LastName", contact.lastName);
                    sqlCommand.Parameters.AddWithValue("@Address", contact.address);
                    sqlCommand.Parameters.AddWithValue("@City", contact.city);
                    sqlCommand.Parameters.AddWithValue("@State", contact.state);
                    sqlCommand.Parameters.AddWithValue("@Zip", contact.zip);
                    sqlCommand.Parameters.AddWithValue("@PhoneNumber", contact.phoneNumber);
                    sqlCommand.Parameters.AddWithValue("@Email", contact.emailId);
                    sqlCommand.Parameters.AddWithValue("@RelationType", contact.contactType);
                    sqlCommand.Parameters.AddWithValue("@AddressBookName", contact.addressBookName);
                    this.sqlconnection.Open();
                    var result = sqlCommand.ExecuteNonQuery();
                    this.sqlconnection.Close();
                    if (result != 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                connection.Close();
            }
            return false;
        }

        // Method to Add List of Contacts To DB Without Thread..................
        public void AddContactListToDBWithoutThread(List<Contact> contactList)
        {

            contactList.ForEach(contact =>
            {
                Console.WriteLine("Contact being added: " + contact.firstName);
                this.AddContact(contact);
                Console.WriteLine("Contact added: " + contact.firstName);
            });
        }

        // Method to Add List of Contacts To DB With Thread......................
        public void AddContactListToDBWithThread(List<Contact> contactList)
        {
            contactList.ForEach(contact =>
            {
                Thread thread = new Thread(() =>
                {
                    Console.WriteLine("Contact Being added" + contact.firstName);
                    this.AddContact(contact);
                    Console.WriteLine("Contact added: " + contact.firstName);
                });
                thread.Start();
                thread.Join();
            });
        }
    }
}
