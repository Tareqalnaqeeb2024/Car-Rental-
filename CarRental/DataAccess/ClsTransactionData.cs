using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace DataAccess
{
   public class ClsTransactionData
    {
        static public int AddNewTransaction(int BookingID, int ReturnID, string PaymentDetails, decimal PaidInitialTotalDueAmount, decimal ActualTotalDueAmount,
            decimal TotalRemaining, decimal TotalRefunedAmount , DateTime TransactionDate, DateTime UpdatedTransactionDate)
        {
      //      @BookingID  int,
      // @ReturnID  int ,
      // @PaymentDetails nvarchar(200),
      //@PaidInitialTotalDueAmount decimal,
      //@ActualTotalDueAmount decimal,
      //@TotalRemaining decimal,
      //@TotalRefunedAmount decimal,
      //@TransactionDate dateTime ,
      //@UpdatedTransactionDate dateTime,
      //@TransactionID int output
            int TranscationID = 0;

            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {

                using (SqlCommand command = new SqlCommand("SP_AddNewTransaction", connection))
                {

                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@BookingID", BookingID);
                    if (ReturnID != -1)
                        command.Parameters.AddWithValue("@ReturnID", ReturnID);
                    else
                        command.Parameters.AddWithValue("@ReturnID", System.DBNull.Value);

                    command.Parameters.AddWithValue("@PaymentDetails", PaymentDetails);

                    if (PaidInitialTotalDueAmount != -1)
                        command.Parameters.AddWithValue("@PaidInitialTotalDueAmount", PaidInitialTotalDueAmount);
                    else
                        command.Parameters.AddWithValue("@PaidInitialTotalDueAmount", DBNull.Value);
                    if (ActualTotalDueAmount != -1)
                        command.Parameters.AddWithValue("@ActualTotalDueAmount", ActualTotalDueAmount);
                    else
                        command.Parameters.AddWithValue("@ActualTotalDueAmount", System.DBNull.Value);

                    command.Parameters.AddWithValue("@TotalRemaining", TotalRemaining);

                    command.Parameters.AddWithValue("@TotalRefunedAmount", TotalRefunedAmount);
                    command.Parameters.AddWithValue("@TransactionDate", TransactionDate);
                    command.Parameters.AddWithValue("@UpdatedTransactionDate", UpdatedTransactionDate);

                    connection.Open();


                    SqlParameter OutPutParmater = new SqlParameter("@TransactionID", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };

                    command.Parameters.Add(OutPutParmater);



                    command.ExecuteNonQuery();

                    TranscationID = (int)OutPutParmater.Value;


                }
            }
            return TranscationID;



        }

        static public DataTable GetAllTransactions()
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {

                connection.Open();

                using (SqlCommand command = new SqlCommand("SP_GetAllTransactions", connection))

                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = command.ExecuteReader())
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

        static public bool GetTransactionByID(int TransactionID ,ref int BookingID,ref int ReturnID,ref string PaymentDetails,
            ref decimal PaidInitialTotalDueAmount,ref decimal ActualTotalDueAmount,
           ref decimal TotalRemaining, ref  decimal TotalRefunedAmount,ref  DateTime TransactionDate,ref  DateTime UpdatedTransactionDate)
        {
            bool IsFound = false;
            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {

                using (SqlCommand command = new SqlCommand("SP_GetTransactionByID", connection))
                {

                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@TransactionID", TransactionID);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())

                    {
                        if (reader.Read())
                        {
                            IsFound = true;
                            BookingID = (int)reader["BookingID"];
                            if (reader["ReturnID"] !=DBNull.Value)
                                ReturnID = (int)reader["ReturnID"];
                            else
                                ReturnID = -1;
                            PaymentDetails = (string)reader["PaymentDetails"];
                            PaidInitialTotalDueAmount = (decimal)reader["PaidInitialTotalDueAmount"];
                            ActualTotalDueAmount = (decimal)reader["ActualTotalDueAmount"];
                            TotalRemaining = (decimal)reader["TotalRemaining"];
                            TotalRefunedAmount = (decimal)reader["TotalRefunedAmount"];
                            TransactionDate = (DateTime)reader["TransactionDate"];
                            UpdatedTransactionDate = (DateTime)reader["UpdatedTransactionDate"];


                        }

                    }
                }


            }
            return IsFound;




        }

        static public bool UpdateTransactionByID(int TransactionID, int BookingID, int ReturnID, string PaymentDetails, decimal PaidInitialTotalDueAmount, decimal ActualTotalDueAmount,
            decimal TotalRemaining, decimal TotalRefunedAmount, DateTime TransactionDate, DateTime UpdatedTransactionDate)

        {
            int rowAffected = 0;


            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {

                using (SqlCommand command = new SqlCommand("SP_UpdateTransaction", connection))
                {

                    command.CommandType = CommandType.StoredProcedure;

                    connection.Open();

                    command.Parameters.AddWithValue("@TransactionID", TransactionID);
                    command.Parameters.AddWithValue("@BookingID", BookingID);
                    command.Parameters.AddWithValue("@ReturnID", ReturnID);
                    command.Parameters.AddWithValue("@PaymentDetails", PaymentDetails);
                    command.Parameters.AddWithValue("@PaidInitialTotalDueAmount", PaidInitialTotalDueAmount);
                    command.Parameters.AddWithValue("@ActualTotalDueAmount", ActualTotalDueAmount);
                    command.Parameters.AddWithValue("@TotalRemaining", TotalRemaining);

                    command.Parameters.AddWithValue("@TotalRefunedAmount", TotalRefunedAmount);
                    command.Parameters.AddWithValue("@TransactionDate", TransactionDate);
                    command.Parameters.AddWithValue("@UpdatedTransactionDate", UpdatedTransactionDate);

                    rowAffected = command.ExecuteNonQuery();



                }
            }

            return (rowAffected > 0);
        }


        static public bool DeleteTransactionByID(int TransactionID)
        {

            int rowAffected = 0;

            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {

                using (SqlCommand command = new SqlCommand("SP_DeleteTransactionByID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // command.Parameters.Add(new SqlParameter("@CustomerID", CustomerID));

                    command.Parameters.AddWithValue("@TransactionID ", TransactionID);

                    connection.Open();

                    rowAffected = command.ExecuteNonQuery();


                }

                return (rowAffected > 0);
            }

        }
    }
}