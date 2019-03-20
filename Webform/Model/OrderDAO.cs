using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webform.AppContext;
using Webform.Entity;
using Webform.Model;

namespace Webform.Model
{
    public class OrderDAO : _DAO
    {
        public static DataTable All()
        {
            string query = "select * from orders";
            return ExecuteQueryTable(query);
        }

        public static int Insert(Order order)
        {
            string query = "INSERT INTO Orders([CustomerID],[OrderDate],[RequiredDate],[ShipAddress]) VALUES(" +
                "@CustomerID," +
                "@OrderDate," +
                "@RequiredDate," +
                "@ShipAddress) ; SELECT SCOPE_IDENTITY() ";

            SqlCommand command = new SqlCommand(query, DBContext.GetConnection());
            command.Connection.Open();

            SqlParameter param1 = new SqlParameter("@CustomerID", SqlDbType.NVarChar);
            param1.Value = order.CustomerID;
            command.Parameters.Add(param1);

            SqlParameter param2 = new SqlParameter("@OrderDate", SqlDbType.DateTime);
            param2.Value = order.OrderDate;
            command.Parameters.Add(param2);

            SqlParameter param3 = new SqlParameter("@RequiredDate", SqlDbType.DateTime);
            param3.Value = order.RequiredDate;
            command.Parameters.Add(param3);

            SqlParameter param4 = new SqlParameter("@ShipAddress", SqlDbType.NVarChar);
            param4.Value = order.ShipAddress;
            command.Parameters.Add(param4);

            int k = Convert.ToInt32(command.ExecuteScalar());
            command.Connection.Close();
            return k;
        }
    }
}
