using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DataAccess
{
    public class ClsCustomersData
    {

        static public int AddNewCustomer(string name ,string NationalID ,string Address ,string Email ,int Phone , int DriverLicense)
        {
            int CustomerID = 0;

            SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString);

            SqlCommand command = new SqlCommand("SP_AddNewCustomer", connection);

            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@Name", name);
            command.Parameters.AddWithValue("@NationalID", NationalID);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@Email", Email);
            command.Parameters.AddWithValue("@Phone", Phone);
            command.Parameters.AddWithValue("@DriverLicense", DriverLicense);

            SqlParameter OutPutParmater = new SqlParameter("@CustomerID", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };

            command.Parameters.Add(OutPutParmater);

            connection.Open();


            command.ExecuteNonQuery();

            CustomerID = (int)OutPutParmater.Value;

            connection.Close();

            return CustomerID ;



        }

        static public DataTable GetAllCustomers()
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {

                connection.Open();

                using (SqlCommand command = new SqlCommand("SP_GetAllCustomers", connection))

                {
                    command.CommandType = CommandType.StoredProcedure;

                    using(SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            dataTable.Load(reader);
                        }
                    }


                }

                return dataTable;



            }


           
        }
       
        static public bool GetCustomerByID(int CustomerID,ref string Name, ref string NationalID, ref string Address, ref string Email, ref int Phone, ref int DriverLicense )
        {
            bool IsFound = false;
            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {

                using(SqlCommand command = new SqlCommand("SP_GetCustomerByID", connection))
                {

                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@CustomerID", CustomerID));

                    connection.Open();

                  using (SqlDataReader reader = command.ExecuteReader())

                    {
                        if (reader.Read())
                        {
                            IsFound = true;
                            Name =(string) reader["Name"];
                            NationalID = (string)reader["NationalID"];
                            Address = (string)reader["Address"];
                            Email = (string)reader["Email"];
                            Phone = (int)reader["Phone"];
                            DriverLicense = (int)reader["DriverLicense"];
                        }
                       
                    }
                }

               
            }
            return IsFound;


            
        }

        static public bool UpdateCustomerByID(int CustomerID , string Name,string NationalID,    string Address,  string Email,  int Phone,
             int DriverLicense)

        {
            int rowAffected = 0;


            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {

                using (SqlCommand command = new SqlCommand("SP_UpdateCustomerByID", connection))
                {

                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@CustomerID", CustomerID));
                    command.Parameters.Add(new SqlParameter("@Name", Name));

                    command.Parameters.Add(new SqlParameter("@NationalID", NationalID));
                    command.Parameters.Add(new SqlParameter("@Address", Address));
                    command.Parameters.Add(new SqlParameter("@Email", Email));
                    command.Parameters.Add(new SqlParameter("@Phone", Phone));
                    command.Parameters.Add(new SqlParameter("@DriverLicense", DriverLicense));

                    connection.Open();

                    rowAffected = command.ExecuteNonQuery();



                }
            }

            return (rowAffected > 0);
        }


        static public bool DeleteCustomerByID(int CustomerID)
        {

            int rowAffected = 0;

            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {

                using (SqlCommand command = new SqlCommand("SP_DeleteCustomerByID",connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // command.Parameters.Add(new SqlParameter("@CustomerID", CustomerID));

                    command.Parameters.AddWithValue("@CustomerID", CustomerID);

                    connection.Open();

                    rowAffected = command.ExecuteNonQuery();


                }

                return (rowAffected > 0);
            }


            
        }
        public static bool CheckIsCustomerExists(int CustomerID)
        {
            bool IsFound = false; 

            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {

                using(SqlCommand command = new SqlCommand("SP_CheckCustomerExists", connection))
                {

                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@CustomerID", CustomerID);

                    connection.Open();


                    SqlParameter OuputParametr = new SqlParameter("@Found", SqlDbType.Bit)
                    {
                        Direction = ParameterDirection.Output
                    };

                    command.Parameters.Add(OuputParametr);
                    command.ExecuteNonQuery();
                    IsFound = (bool)OuputParametr.Value;
                }
            }

            return IsFound;
        }


       

    }
}
