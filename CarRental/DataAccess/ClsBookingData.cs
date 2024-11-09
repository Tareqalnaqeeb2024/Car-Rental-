using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;



namespace DataAccess
{
   public class ClsBookingData
    {
        static public int AddNewBooking(int CustomerID , int VehicleID , DateTime StartDate , DateTime EndDate, string PickUpLocation,
            string DropOffLocation ,int InitialRentalDays,   decimal RentalPricePerDay, decimal InitialTotalDueAmount , string InitialCheckNotes)
        {
      //CustomerID]
      //VehivleID]
      //StartDate]
      //EndDate]
      //PickUpLocation]
      //DropOffLocation]
      //InitialRentalDays]
      //RentalPricePerDay]
      //InitialTotalDueAmount]
      //InitialCheckNotes]
            int BookingID = 0;

            SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString);

            SqlCommand command = new SqlCommand("SP_AddNewBooking", connection);

            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@CustomerID",CustomerID);
            command.Parameters.AddWithValue("@VehicleID", VehicleID);
            command.Parameters.AddWithValue("@StartDate", StartDate);
            command.Parameters.AddWithValue("@EndDate", EndDate);
            command.Parameters.AddWithValue("@PickUpLocation", PickUpLocation);
            command.Parameters.AddWithValue("@DropOffLocation", DropOffLocation);
          
            command.Parameters.AddWithValue("@InitialRentalDays", InitialRentalDays);
            command.Parameters.AddWithValue("@RentalPricePerDay", RentalPricePerDay);
            command.Parameters.AddWithValue("@InitialTotalDueAmount", InitialTotalDueAmount);
            command.Parameters.AddWithValue("@InitialCheckNotes", InitialCheckNotes);


            SqlParameter OutPutParmater = new SqlParameter("@BookingID", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };

            command.Parameters.Add(OutPutParmater);

            connection.Open();


            command.ExecuteNonQuery();

            BookingID = (int)OutPutParmater.Value;

            connection.Close();

            return BookingID;



        }

        static public DataTable GetAllBookings()
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {

                connection.Open();

                using (SqlCommand command = new SqlCommand("SP_GetAllBookings", connection))

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

        static public bool GetBookingByID(int BookingID ,ref int CustomerID, ref int VehicleID,ref DateTime StartDate,ref DateTime EndDate,ref string PickUpLocation,
           ref string DropOffLocation,ref int InitialRentalDays,ref decimal RentalPricePerDay,ref decimal InitialTotalDueAmount,ref string InitialCheckNotes)
        {
          bool  IsFound = false;
            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {

                using (SqlCommand command = new SqlCommand("SP_GetBookingByID", connection))
                {

                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@BookingID", BookingID);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())

                    {
                        if (reader.Read())
                        {
                            IsFound = true;
                            BookingID = (int)reader["BookingID"];
                            CustomerID = (int)reader["CustomerID"];
                            VehicleID = (int)reader["VehicleID"];
                            StartDate = (DateTime)reader["StartDate"];
                            EndDate = (DateTime)reader["EndDate"];
                            PickUpLocation = (string)reader["PickUpLocation"];
                            DropOffLocation = (string)reader["DropOffLocation"];
                            InitialRentalDays = (int)reader["InitialRentalDays"];
                            RentalPricePerDay = (decimal)reader["RentalPricePerDay"];
                            InitialTotalDueAmount = (decimal)reader["InitialTotalDueAmount"];
                            InitialCheckNotes = (string)reader["InitialCheckNotes"];
                        }

                    }
                }


            }
            return IsFound;



        }

        static public bool UpdateBookingByID(int BookingID, int CustomerID, int VehicleID, DateTime StartDate, DateTime EndDate, string PickUpLocation,
            string DropOffLocation, int InitialRentalDays, decimal RentalPricePerDay, decimal InitialTotalDueAmount, string InitialCheckNotes)

        {
            int rowAffected = 0;


            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {

                using (SqlCommand command = new SqlCommand("SP_UpdateBooking", connection))
                {

                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@BookingID", BookingID);

                    command.Parameters.AddWithValue("@CustomerID", CustomerID);
                    command.Parameters.AddWithValue("@VehicleID", VehicleID);
                    command.Parameters.AddWithValue("@StartDate", StartDate);
                    command.Parameters.AddWithValue("@EndDate", EndDate);
                    command.Parameters.AddWithValue("@PickUpLocation", PickUpLocation);
                    command.Parameters.AddWithValue("@DropOffLocation", DropOffLocation);

                    command.Parameters.AddWithValue("@InitialRentalDays", InitialRentalDays);
                    command.Parameters.AddWithValue("@RentalPricePerDay", RentalPricePerDay);
                    command.Parameters.AddWithValue("@InitialTotalDueAmount", InitialTotalDueAmount);
                    command.Parameters.AddWithValue("@InitialCheckNotes", InitialCheckNotes);
                    connection.Open();

                    rowAffected = command.ExecuteNonQuery();



                }
            }

            return (rowAffected > 0);
        }


        static public bool DeleteBookingByID(int BookingID)
        {

            int rowAffected = 0;

            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {

                using (SqlCommand command = new SqlCommand("SP_DeleteBookingByID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // command.Parameters.Add(new SqlParameter("@CustomerID", CustomerID));

                    command.Parameters.AddWithValue("@BookingID", BookingID);

                    connection.Open();

                    rowAffected = command.ExecuteNonQuery();


                }

                //return (rowAffected > 0);
            }

            return (rowAffected > 0);


        }


        static public bool CheckBookingExists(int BookingID)
        {

            bool IsFound = false;

            using(SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {

                using(SqlCommand command = new SqlCommand("SP_CheckBookingExists", connection))
                {

                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@BookingID", BookingID);

                    connection.Open();

                  using(SqlDataReader reader = command.ExecuteReader())

                    {
                        if (reader.Read())
                        {
                            IsFound = true;
                        }
                    }
                }
            }

            return IsFound;
        }
    }
}
