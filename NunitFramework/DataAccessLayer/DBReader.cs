using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitFramework.DataAccessLayer
{
    class DBReader
    {
        static String connectionString = ConfigurationManager.ConnectionStrings["msdbmphasis"].ConnectionString;

        public DataTable ExecuteQueryToDataTable(String query)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            SqlCommand command = new SqlCommand(query, connection);
            
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command);

            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);

            return dt;
        }


        public int ExecuteQueryToUpdate(String query)
        {
            int rowaffected = -1;
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);

                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                 rowaffected = command.ExecuteNonQuery();
                connection.Close();
            }
            catch
            {

            }

            return rowaffected;
        }


    }
}
