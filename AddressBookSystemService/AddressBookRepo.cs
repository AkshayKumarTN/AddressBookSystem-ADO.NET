using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace AddressBookSystemService
{
    public class AddressBookRepo
    {
        public static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AddressBookSystem;Integrated Security=True";
        SqlConnection sqlconnection = new SqlConnection(connectionString);

        // Method to Retrive All data from database.........................
        public void GetAllEmployee()
        {
            try
            {
                Contact contact = new Contact();
                using (this.sqlconnection)
                {
                    string query = @"select * from AddressBookTable";
                    SqlCommand command = new SqlCommand(query, this.sqlconnection);
                    this.sqlconnection.Open();
                    SqlDataReader dataReader = command.ExecuteReader();
                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            contact.firstName = dataReader["FirstName"].ToString();
                            contact.lastName = dataReader["LastName"].ToString();
                            contact.address = dataReader["Address"].ToString();
                            contact.city = dataReader["City"].ToString();
                            contact.state = dataReader["State"].ToString();
                            contact.zip = Convert.ToDecimal(dataReader["Zip"]);
                            contact.phoneNumber = Convert.ToDecimal(dataReader["PhoneNumber"]);
                            contact.emailId = dataReader["Email"].ToString();
                            contact.contactType = dataReader["RelationType"].ToString();
                            contact.addressBookName = dataReader["AddressBookName"].ToString();
                            
                            Console.WriteLine(contact.firstName + " " + contact.lastName + " " + contact.address + " " + contact.city + " " +
                                contact.state + " " + contact.zip + " " + contact.phoneNumber + " " + contact.emailId
                                + " " + contact.contactType + " " + contact.addressBookName);
                            Console.WriteLine("---------------------------------------------------------------------------------------");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No data found");
                    }
                    dataReader.Close();
                    this.sqlconnection.Close();
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            finally
            {
                this.sqlconnection.Close();
            }
        }
    }
}
