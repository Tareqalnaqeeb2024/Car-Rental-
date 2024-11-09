using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace DataAccess
{
   public class ClsPlateDetailsData
    {
        static public int AddNewPlate(int PlateNumber, string PlateType ,int CityNumber)
        {
            int PlateID = -1;
            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString) )

            {

                using (SqlCommand command = new SqlCommand("SP_AddNewPlate", connection))
                {

                    command.CommandType = CommandType.StoredProcedure;

                    connection.Open();
                    command.Parameters.AddWithValue("@PlateNumber", PlateNumber);
                    command.Parameters.AddWithValue("@PlateType",PlateType);
                    command.Parameters.AddWithValue("@CityNumber", CityNumber);


                    SqlParameter outputParamater = new SqlParameter("@PlateID", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };

                    command.Parameters.Add(outputParamater);

                    command.ExecuteNonQuery();


                    PlateID =(int) outputParamater.Value;


                    



                }
            }

            return PlateID;
        }


        public static bool UpdatePlate(int PlateID, int PlateNumber, string PlateType, int CityNumber)
        {

            int rowAffcted = 0;
            using(SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {
                
                using (SqlCommand command = new SqlCommand("SP_UpdatePlateDetails", connection))
                {

                    command.CommandType = CommandType.StoredProcedure;

                    connection.Open();
                    command.Parameters.AddWithValue("@PlateID", PlateID);

                    command.Parameters.AddWithValue("@PlateNumber", PlateNumber);
                    command.Parameters.AddWithValue("@PlateType", PlateType);
                    command.Parameters.AddWithValue("@CityNumber", CityNumber);

                    rowAffcted = command.ExecuteNonQuery();


                }
            }

            return (rowAffcted > 0);
        }


        static public bool GetPlateDetailsByID(int PlateID , ref int PlateNumber , ref string PlateType ,ref int CityNumber)
        {
            bool IsFound = false; 


            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {

                using (SqlCommand command = new SqlCommand("SP_GetPlateDetailsByID", connection))
                {

                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@PlateID", PlateID);

                    connection.Open();

                    using(SqlDataReader reader =command.ExecuteReader())
                    {

                        if(reader.Read())
                        {
                            IsFound = true;

                            PlateNumber = (int)reader["PlateNumber"];
                            PlateType = (string)reader["PlateType"];
                            CityNumber = (int)reader["CityNumber"];


                        }
                    }
                }

            }

            return IsFound;
        }

        static public bool GetPlateDetailsByPlateNumber(  int PlateNumber,ref  int PlateID, ref string PlateType, ref int CityNumber)
        {
            bool IsFound = false;


            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {

                using (SqlCommand command = new SqlCommand("SP_GetPlateDetailsByPlateNumber", connection))
                {

                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@PlateNumber", PlateNumber);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        if (reader.Read())
                        {
                            IsFound = true;

                            
                            PlateID = (int)reader["PlateID"];
                            PlateType = (string)reader["PlateType"];
                            CityNumber = (int)reader["CityNumber"];


                        }
                    }
                }

            }

            return IsFound;
        }



        static public DataTable GetAllPlateDetails()
        {
            DataTable dataTable = new DataTable();
            

            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {


                using (SqlCommand command = new SqlCommand("SP_GetAllPlateDetails", connection))


                {
                    command.CommandType = CommandType.StoredProcedure;

                    connection.Open();


                    using (SqlDataReader reader =command.ExecuteReader())
                    {


                        if (reader.HasRows)
                        {
                            dataTable.Load(reader);
                        }
                    }

                }
            }


            return dataTable;
        }


        static public bool DeletePlateDetailsByID(int PlateID)
        {

            int rowAfftedted = 0;
            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))

            {


                using(SqlCommand command = new SqlCommand("SP_DeletePlateDetailsByID", connection))
                {


                    command.CommandType = CommandType.StoredProcedure;

                    connection.Open();


                    command.Parameters.AddWithValue("@PlateID", PlateID);



                    rowAfftedted = command.ExecuteNonQuery();



                }
            }


            return (rowAfftedted > 0);
        }
    }
}
