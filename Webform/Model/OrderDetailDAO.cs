using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Webform.AppContext;
using Webform.Entity;

namespace Webform.Model
{
    public  class OrderDetailDAO : _DAO
    {
        public static int Insert(OrderDetail orderDetail)
        {
            string query = "INSERT INTO [Order Details]([OrderID],[ProductID],[UnitPrice],[Quantity],[Discount])VALUES(" +
                "@OrderID," +
                "@ProductID," +
                "@UnitPrice," +
                "@Quantity," +
                "@Discount)";

            SqlCommand command = new SqlCommand(query, DBContext.GetConnection());
            command.Connection.Open();

            SqlParameter param1 = new SqlParameter("@OrderID", SqlDbType.Int);
            param1.Value = orderDetail.OrderID;
            command.Parameters.Add(param1);

            SqlParameter param2 = new SqlParameter("@ProductID", SqlDbType.Int);
            param2.Value = orderDetail.ProductID;
            command.Parameters.Add(param2);

            SqlParameter param3 = new SqlParameter("@UnitPrice", SqlDbType.Float);
            param3.Value = orderDetail.UnitPrice;
            command.Parameters.Add(param3);

            SqlParameter param4 = new SqlParameter("@Quantity", SqlDbType.Int);
            param4.Value = orderDetail.Quantity;
            command.Parameters.Add(param4);

            SqlParameter param5 = new SqlParameter("@Discount", SqlDbType.Int);
            param5.Value = orderDetail.Discount;
            command.Parameters.Add(param5);

            int k = command.ExecuteNonQuery();
            command.Connection.Close();
            return k;
        }
    }
}