using App.AppContext;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace App.Model
{
    public class DAO
    {
        public static DataTable ExecuteQueryTable(string query)
        {
            SqlCommand command = new SqlCommand(query, DBContext.GetConnection());
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            return ds.Tables[0];
        }

        public static DataRow ExecuteQueryRow(string query)
        {
            DataTable dt = ExecuteQueryTable(query);
            if (dt.Rows.Count == 0) return null;
            return dt.Rows[0];
        }

        public static int ExecuteNoQuery(string query)
        {
            SqlCommand command = new SqlCommand(query, DBContext.GetConnection());
            command.Connection.Open();
            int k = command.ExecuteNonQuery();
            command.Connection.Close();
            return k;
        }


        // ============= Execute with sql command ================= //

        public static DataTable ExecuteQueryTable(SqlCommand command)
        {
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            return ds.Tables[0];
        }

        public static DataRow ExecuteQueryRow(SqlCommand command)
        {
            DataTable dt = ExecuteQueryTable(command);
            if(dt.Rows.Count == 0) return null;
            return dt.Rows[0];
        }

        public static int ExecuteNoQuery(SqlCommand command)
        {
            command.Connection.Open();
            int k = command.ExecuteNonQuery();
            command.Connection.Close();
            return k;
        }



        public static SqlParameter param(string paramName, SqlDbType sqlType, object value)
        {
            return new SqlParameter()
            {
                ParameterName = paramName,
                SqlDbType = sqlType,
                Value = value,
            };
        }
    }
}