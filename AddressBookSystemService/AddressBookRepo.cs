using System;
using System.Collections.Generic;
using System.Data;
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

        // Method to Count Contact By State Or City........................
        public void CountOfContacts()
        {
            SqlConnection sqlconnection = new SqlConnection(connectionString);
            try
            {
                using (this.sqlconnection)
                {
                    string query = @"select State, COUNT(State) from AddressBookTable group by State";
                    SqlCommand command = new SqlCommand(query, sqlconnection);
                    sqlconnection.Open();
                    SqlDataReader dataReader = command.ExecuteReader();
                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            Console.Write(dataReader.GetString(0) + "\t" + dataReader.GetInt32(1));
                            Console.WriteLine("\n");
                        }
                        sqlconnection.Close();
                    }
                    else
                    {
                        Console.WriteLine("No data found");
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            finally
            {
                this.sqlconnection.Close();
            }
        }

        //
        public bool AddContact(Contact contact)
        {
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
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            finally
            {
                this.sqlconnection.Close();
            }
            return false;
        }
    }
}
