using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsForms.AppContext;

namespace WindowsForms.Model
{
    public class CategoryDAO : _DAO
    {
        public static DataTable All()
        {
            string query = "select * from Categories";
            return ExecuteQueryTable(query);
        }

        public static DataRow Get(int id)
        {
            string query = "select * from Categories where CategoryID = @categoryId";

            SqlCommand sqlCommand = new SqlCommand(query, DBContext.GetConnection());
            SqlParameter parameter = new SqlParameter("categoryId", id);
            sqlCommand.Parameters.Add(parameter);

            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);

            DataSet ds = new DataSet();

            adapter.Fill(ds);
            return ds.Tables[0].Rows[0];
        }
    }
}
