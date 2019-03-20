using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsForms.AppContext;

namespace WindowsForms.Model
{
    public class _DAO
    {
        public static DataTable ExecuteQueryTable(string query)
        {
            SqlCommand command = new SqlCommand(query, DBContext.GetConnection());
            //command.CommandType = CommandType.Text;
            SqlDataAdapter adapter = new SqlDataAdapter(command);

            DataSet ds = new DataSet();

            // start connection, get record and fill records
            adapter.Fill(ds);

            return ds.Tables[0];
        }

        public static DataRow ExecuteQueryRow(string query)
        {
            DataTable dataTable = ExecuteQueryTable(query);
            return dataTable.Rows[0];
        }

        public static int ExecuteNoQuery(string query)
        {
            SqlCommand command = new SqlCommand(query, DBContext.GetConnection());
            command.Connection.Open();

            int k = command.ExecuteNonQuery();

            command.Connection.Close();

            return k;
        }
    }
}
