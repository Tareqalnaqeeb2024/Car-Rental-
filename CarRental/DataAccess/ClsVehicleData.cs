using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
   public  class ClsVehicleData
    {

        static public  int AddNewVehicle(string Make, string Model, int MadeYear, int Mileage, int FuleTypeID, int PlateNumberID,
            decimal RentalPricePerDay, bool IsAvailable, string ImagePath)
        {
            int VehicleID = -1;

            //          @Make nvarchar(50),
            // @Model nvarchar(50),
            //@MadeYear int ,
            //      @Mileage int ,
            //      @FuleTypeID int ,
            //      @PlateNumberID int,
            //      @RentalPricePerDay decimal,
            //      @IsAvailable bit,
            ////@ImagePath nvarchar(200),
            //@VehicleID int output
            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {

                using (SqlCommand command = new SqlCommand("SP_AddNewVehicle", connection))
                {

                    command.CommandType = CommandType.StoredProcedure;


                    command.Parameters.AddWithValue("@Make", Make);
                    command.Parameters.AddWithValue("@Model", Model);
                    command.Parameters.AddWithValue("@MadeYear", MadeYear);
                    command.Parameters.AddWithValue("@Mileage", Mileage);
                    command.Parameters.AddWithValue("@FuleTypeID", FuleTypeID);
                    command.Parameters.AddWithValue("@PlateNumberID", PlateNumberID);
                    command.Parameters.AddWithValue("@RentalPricePerDay", RentalPricePerDay);
                    command.Parameters.AddWithValue("@IsAvailable", IsAvailable);
                    command.Parameters.AddWithValue("@ImagePath", ImagePath);

                    connection.Open();

                    SqlParameter OutputParamters = new SqlParameter("@VehicleID", SqlDbType.Int)

                    {
                        Direction = ParameterDirection.Output

                    };


                    command.Parameters.Add(OutputParamters);

                    command.ExecuteNonQuery();
                    VehicleID = (int)OutputParamters.Value;






                }
            }

            return VehicleID;
        }


        public static bool UpdateVehicle(int VechileID, string Make, string Model, int MadeYear, int Mileage, int FuleTypeID, int PlateNumberID,
            decimal RentalPricePerDay, bool IsAvailable, string ImagePath)

        {

            int rowAffted = 0;


            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {

                using (SqlCommand command = new SqlCommand("SP_UpdateVehicle", connection))

                {

                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@VehicleID", VechileID);
                    command.Parameters.AddWithValue("@Make", Make);
                    command.Parameters.AddWithValue("@Model", Model);
                    command.Parameters.AddWithValue("@MadeYear", MadeYear);
                    command.Parameters.AddWithValue("@Mileage", Mileage);
                    command.Parameters.AddWithValue("@FuleTypeID", FuleTypeID);
                    command.Parameters.AddWithValue("@PlateNumberID", PlateNumberID);
                    command.Parameters.AddWithValue("@RentalPricePerDay", RentalPricePerDay);
                    command.Parameters.AddWithValue("@IsAvailable", IsAvailable);
                    if (ImagePath != "")
                        command.Parameters.AddWithValue("@ImagePath", ImagePath);
                    else
                        command.Parameters.AddWithValue("@ImagePath", DBNull.Value);
                    connection.Open();



                    rowAffted = command.ExecuteNonQuery();


                }
            }

            return rowAffted > 0;

        }



        public static bool GetVehicleByID(int VehicleID,ref string Make, ref  string Model, ref int MadeYear,ref  int Mileage,ref int FuleTypeID,ref int PlateNumberID,
           ref decimal RentalPricePerDay,ref bool IsAvailable, ref string ImagePath)
        {

            bool ISFound = false;

            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {

                using (SqlCommand command = new SqlCommand("SP_GetVehicleByID", connection))
                {

                    connection.Open();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@VehicleID", VehicleID);

                    using (SqlDataReader reader = command.ExecuteReader())

                    {

                        if (reader.Read())
                        {
                            ISFound = true;

                            Make = (string)reader["Make"];
                            Model = (string)reader["Model"];
                            MadeYear = (int)reader["MadeYear"];
                            Mileage = (int)reader["Mileage"];
                            FuleTypeID = (int)reader["FuleTypeID"];
                            PlateNumberID = (int)reader["PlateNumberID"];
                            RentalPricePerDay = (decimal)reader["RentalPricePerDay"];
                            IsAvailable = (bool)reader["IsAvailable"];
                            if (reader["ImagePath"] != DBNull.Value)
                            {
                                ImagePath = (string)reader["ImagePath"];
                            }
                            else
                            {
                                ImagePath = "";
                            }
                        }
                        else
                        {
                            ISFound = false;
                        }
                    }
                }


            }

            return ISFound;

        }

        public static bool GetVehicleByID2(int VehicleID )
        {
            string Make;string Model; int MadeYear;  int Mileage; int FuleTypeID; int PlateNumberID;
            decimal RentalPricePerDay;  bool IsAvailable; string ImagePath;
            //DataTable dataTable = new DataTable();
            bool ISFound = true ; 
            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {

                using (SqlCommand command = new SqlCommand("SP_GetVehicleByID2", connection))
                {

                    command.CommandType = CommandType.StoredProcedure;

                   // command.Parameters.AddWithValue("@VehicleID", VehicleID);
                    command.Parameters.Add(new SqlParameter("@VehicleID", VehicleID));
                    connection.Open();


                    SqlParameter OutputParamter1 = new SqlParameter("@Make", SqlDbType.NVarChar);
                    SqlParameter OutputParamter2 = new SqlParameter("@Model", SqlDbType.NVarChar);
                    SqlParameter OutputParamter3 = new SqlParameter("@MadeYear", SqlDbType.Int);
                    SqlParameter OutputParamter4 = new SqlParameter("@Mileage", SqlDbType.Int);
                    SqlParameter OutputParamter5 = new SqlParameter("@FuleTypeID", SqlDbType.Int);
                    SqlParameter OutputParamter6 = new SqlParameter("@PlateNumberID", SqlDbType.Int);
                    SqlParameter OutputParamter7 = new SqlParameter("@RentalPricePerDay", SqlDbType.Decimal);
                    SqlParameter OutputParamter8 = new SqlParameter("@IsAvailable", SqlDbType.Bit);
                    SqlParameter OutputParamter9 = new SqlParameter("@IsFound", SqlDbType.Bit);





                    //command.Parameters.AddWithValue("@Make", Make);
                    //command.Parameters.AddWithValue("@Model", Model);
                    //command.Parameters.AddWithValue("@MadeYear", MadeYear);
                    //command.Parameters.AddWithValue("@Mileage", Mileage);
                    //command.Parameters.AddWithValue("@FuleTypeID", FuleTypeID);
                    //command.Parameters.AddWithValue("@PlateNumberID", PlateNumberID);
                    //command.Parameters.AddWithValue("@RentalPricePerDay", RentalPricePerDay);
                    //command.Parameters.AddWithValue("@IsAvailable", IsAvailable);
                    //command.Parameters.AddWithValue("@ImagePath", ImagePath);
                    //command.Parameters.AddWithValue("@IsFound", ISFound);
                    using (SqlDataReader reader = command.ExecuteReader())

                    {

                        if (reader.Read())
                        {
                            ISFound = true;

                            Make = (string)reader["Make"];
                            Model = (string)reader["Model"];
                            MadeYear = (int)reader["MadeYear"];
                            Mileage = (int)reader["Mileage"];
                            FuleTypeID = (int)reader["FuleTypeID"];
                            PlateNumberID = (int)reader["PlateNumberID"];
                            RentalPricePerDay = (decimal)reader["RentalPricePerDay"];
                            IsAvailable = (bool)reader["IsAvailable"];
                            ImagePath = (string)reader["ImagePath"];
                        }
                    }
                }


            }

            return ISFound;

        }


        public static bool DeleteVehicleByID(int VehicleID)
        {

            int rowAffted = 0;

            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {

                using (SqlCommand command = new SqlCommand("SP_DeleteVehicleByID", connection))
                {

                    connection.Open();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@VehicleID", VehicleID);


                    rowAffted = command.ExecuteNonQuery();
                }

            }
            return (rowAffted > 0);

        }

        public static DataTable GetAllVechiles()
        {
            DataTable dataTable = new DataTable();


            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {

                using (SqlCommand command = new SqlCommand("SP_GetAllVehicles", connection)) 

                {
                    command.CommandType = CommandType.StoredProcedure;

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        if(reader.HasRows)
                        {
                            dataTable.Load(reader);
                        }
                        else
                        {
                            dataTable = null;
                        }

                    }
                }
            }
            return dataTable;
        }

        public static bool CheckIsVehicleExists(int VehicleID)
        {
            bool IsFound = false;

            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {

                using (SqlCommand command = new SqlCommand("SP_CheckVehicleExists", connection))
                {

                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@VehicleID", VehicleID);

                    connection.Open();

                    SqlParameter OutPutParametrs = new SqlParameter("@Found", SqlDbType.Bit)
                    {
                        Direction = ParameterDirection.Output
                        
                      };

                    command.Parameters.Add(OutPutParametrs);
                    command.ExecuteNonQuery();
                    IsFound = (bool)OutPutParametrs.Value;

                    
                }
            }

            return IsFound;
        }

        static public bool IsVehicleAvialable(int VehicleID)
        {
            bool IsFound = false;

            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {

                using (SqlCommand command = new SqlCommand("SP_IsVehicleAvialable", connection))
                {

                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@VehicleID", VehicleID);

                    connection.Open();

                    SqlParameter OutPutParametrs = new SqlParameter("@IsAvialable", SqlDbType.Bit)
                    {
                        Direction = ParameterDirection.Output

                    };

                    command.Parameters.Add(OutPutParametrs);
                    command.ExecuteNonQuery();
                    IsFound = (bool)OutPutParametrs.Value;


                }
            }

            return IsFound;
        }
    }
}
