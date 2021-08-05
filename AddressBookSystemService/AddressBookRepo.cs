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

        // Method to Update data in database..................
        public bool UpdateTables()
        {
            string query = @"update AddressBookTable set PhoneNumber = 2345688996 where Firstname = 'Surya'";
            using (this.sqlconnection)
            {
                try
                {
                    this.sqlconnection.Open();
                    SqlCommand command = new SqlCommand(query, this.sqlconnection);
                    int updatedRows = command.ExecuteNonQuery();
                    if (updatedRows != 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
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

        // Method to Retrive Contact In A Particular Period From DB................
        public List<string> GetDataInParticularRange()
        {
            Contact contact = new Contact();
            List<string> data = new List<string>();
            try
            {
                using (this.sqlconnection)
                {
                    string query = @"SELECT * FROM Contact where AddedDate between CAST('2021-02-01' AS DATE) AND SYSDATETIME()";
                    SqlCommand command = new SqlCommand(query, sqlconnection);
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

                            Console.WriteLine(contact.firstName + " " + contact.lastName + " " + contact.address + " " + contact.city + " " +
                                contact.state + " " + contact.zip + " " + contact.phoneNumber);
                            Console.WriteLine("---------------------------------------------------------------------------------------");
                        }
                        dataReader.Close();
                        return data;
                    }
                    else
                    {
                        throw new Exception("No data found");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                this.sqlconnection.Close();
            }
        }
    }
}
