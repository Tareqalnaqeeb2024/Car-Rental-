using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
  public  class ClsVehicleReturnData
    {
        

        public static int AddNewReturn(DateTime ActualReturnDate, int ActualRentalDays , int Mileage , int ConsumedMileage , string FinalCheckNotes,
           string AddtionalCharges , decimal ActualTotalDueAmount)
        {
            int ReturnID = -1;

            using(SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {

                using (SqlCommand command = new SqlCommand("SP_AddNewReturn", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    connection.Open();

                    command.Parameters.AddWithValue("@ActualReturnDate", ActualReturnDate);
                    command.Parameters.AddWithValue("@ActualRentalDays", ActualRentalDays);
                    command.Parameters.AddWithValue("@Mileage", Mileage);
                    command.Parameters.AddWithValue("@ConsumedMileage", ConsumedMileage);

                    if (FinalCheckNotes != null && FinalCheckNotes != "")
                        command.Parameters.AddWithValue("@FinalCheckNotes", FinalCheckNotes);
                    else
                        command.Parameters.AddWithValue("@FinalCheckNotes", DBNull.Value);

                    if(AddtionalCharges != null && AddtionalCharges != "")
                    command.Parameters.AddWithValue("@AddtionalCharges", AddtionalCharges);
                    else
                        command.Parameters.AddWithValue("@AddtionalCharges", DBNull.Value);


                    command.Parameters.AddWithValue("@ActualTotalDueAmount", ActualTotalDueAmount);

                    SqlParameter OutputParametrs = new SqlParameter("@ReturnID", SqlDbType.Int)
                    {
                        Direction  = ParameterDirection.Output
                       

                    };


                    command.Parameters.Add(OutputParametrs);
                    command.ExecuteNonQuery();
                    ReturnID = (int)OutputParametrs.Value;



                }
            }
            return ReturnID;

        }


        public static bool UpdateReturn(int ReturnID , DateTime ActualReturnDate, int ActualRentalDays, int Mileage, int ConsumedMileage, string FinalCheckNotes,
           string AddtionalCharges, decimal ActualTotalDueAmount)
        {

            int RowAffcted = 0;

            using(SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {

                using (SqlCommand command = new SqlCommand("SP_UpdateReturn", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    connection.Open();
                    command.Parameters.AddWithValue("@ReturnID", ReturnID);
                    command.Parameters.AddWithValue("@ActualReturnDate", ActualReturnDate);
                    command.Parameters.AddWithValue("@ActualRentalDays", ActualRentalDays);
                    command.Parameters.AddWithValue("@Mileage", Mileage);
                    command.Parameters.AddWithValue("@ConsumedMileage", ConsumedMileage);
                    if (FinalCheckNotes != null && FinalCheckNotes != "")
                        command.Parameters.AddWithValue("@FinalCheckNotes", FinalCheckNotes);
                    else
                        command.Parameters.AddWithValue("@FinalCheckNotes", DBNull.Value);

                    if (AddtionalCharges != null && AddtionalCharges != "")
                        command.Parameters.AddWithValue("@AddtionalCharges", AddtionalCharges);
                    else
                        command.Parameters.AddWithValue("@AddtionalCharges", DBNull.Value);
                    command.Parameters.AddWithValue("@ActualTotalDueAmount", ActualTotalDueAmount);


                    RowAffcted = command.ExecuteNonQuery();


                }
            }
            return (RowAffcted > 0);
        }

       public static DataTable GetAllReturns()
        {
            DataTable dataTable = new DataTable();
            using(SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {

                using (SqlCommand command = new SqlCommand("SP_GetAllVehiclesReturns", connection))
                {

                    command.CommandType = CommandType.StoredProcedure;

                    connection.Open();

                    using(SqlDataReader reader = command.ExecuteReader())
                    {
                        if(reader.HasRows)
                        {
                            dataTable.Load(reader);
                        }
                    }
                }
            }
            return dataTable;
        }


        public static bool FindVehicleReturnByID(int ReturnID,ref DateTime ActualReturnDate,ref int ActualRentalDays,ref int Mileage,ref int ConsumedMileage,ref string FinalCheckNotes,
          ref string AddtionalCharges,ref decimal ActualTotalDueAmount)
        {

            bool IsFound = false;

            using(SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {

                using (SqlCommand command = new SqlCommand("SP_GetReturnVehicelByID", connection))
                {

                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@ReturnID", ReturnID);
                    connection.Open();

                    using(SqlDataReader reader = command.ExecuteReader() )

                    {
                        if (reader.Read())
                        {
                            IsFound = true;

                            ActualReturnDate = (DateTime)reader["ActualReturnDate"];
                            ActualRentalDays = (int)reader["ActualRentalDays"];
                            Mileage = (int)reader["Mileage"];
                            ConsumedMileage = (int)reader["ConsumedMileage"];
                            if (reader["FinalCheckNotes"] != DBNull.Value)
                                FinalCheckNotes = (string)reader["FinalCheckNotes"];
                            else
                                FinalCheckNotes = "";
                            if (reader["AddtionalCharges"] != DBNull.Value)
                                AddtionalCharges = (string)reader["AddtionalCharges"];
                            else
                                AddtionalCharges = "";
                            ActualTotalDueAmount = (decimal)reader["ActualTotalDueAmount"];
                        }
                    }
                }
            }

            return IsFound;
        }

        public static bool DeleteReturnID( int ReturnID)
        {
            int rowAffcted = 0;


            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_DeleteVehicleReturn",connection))
                {

                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@ReturnID", ReturnID);

                    connection.Open();


                    rowAffcted = command.ExecuteNonQuery();
                }
            }

            return (rowAffcted > 0);

        }

        
    }
}
