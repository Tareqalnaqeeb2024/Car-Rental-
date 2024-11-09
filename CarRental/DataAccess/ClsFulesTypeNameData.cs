using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
   public class ClsFulesTypeNameData
    {

        public static DataTable GetAllFulesTypesName()
        {

            DataTable dataTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {

                using(SqlCommand command = new SqlCommand("SP_GetAllFulesNames",connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
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

        static public bool GetFuleTypeNameByID(int FuleID,ref string FuleTypeName )

        {
            bool IsFound = false;


            using (SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString))
            {

                using (SqlCommand command = new SqlCommand("SP_GetFuleTypeByID", connection))
                {

                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@FuleID", FuleID);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        if (reader.Read())
                        {
                            IsFound = true;


                            FuleTypeName = (string)reader["FuleTypeName"];


                        }
                    }
                }

            }
            return IsFound;


        }
    }
}
