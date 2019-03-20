using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsForms.AppContext;
using WindowsForms.Entity;

namespace WindowsForms.Model
{
    public class ProductDAO : _DAO
    {
        public static DataTable All()
        {
            string query = "select * from Products";
            return ExecuteQueryTable(query);
        }
        public static DataRow Get(int productId)
        {
            string query = "select * from Products where productId = " + productId.ToString();
            return ExecuteQueryRow(query);
        }

        public static DataTable GetByCategory(int categoryId)
        {
            string query = "select * from Products where CategoryId = " + categoryId.ToString();
            return ExecuteQueryTable(query);
        }

        public static int Insert(Product product)
        {
            string query = "INSERT INTO Products VALUES (" +
                "@ProductName, " +
                "@CategoryId," +
                "@SupplierId," +
                "@QuantityPerUnit," +
                "@UnitPrice," +
                "@UnitsInStock," +
                "null," +
                "@ReorderLevel," +
                "@Discontinued)";
            SqlCommand command = new SqlCommand(query, DBContext.GetConnection());
            command.Connection.Open();

            command.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@ProductName",
                SqlDbType = SqlDbType.NVarChar,
                Value = product.ProductName
            });

            SqlParameter param2 = new SqlParameter("@CategoryId", SqlDbType.Int);
            param2.Value = product.CategoryId;
            command.Parameters.Add(param2);

            SqlParameter param3 = new SqlParameter("@SupplierId", SqlDbType.Int);
            param3.Value = product.SupplierId;
            command.Parameters.Add(param3);

            SqlParameter param4 = new SqlParameter("@QuantityPerUnit", SqlDbType.NVarChar);
            param4.Value = product.QuantityPerUnit;
            command.Parameters.Add(param4);

            SqlParameter param5 = new SqlParameter("@UnitPrice", SqlDbType.Money);
            param5.Value = product.UnitPrice;
            command.Parameters.Add(param5);

            SqlParameter param6 = new SqlParameter("@UnitsInStock", SqlDbType.Int);
            param6.Value = product.UnitsInStock;
            command.Parameters.Add(param6);

            SqlParameter param7 = new SqlParameter("@ReorderLevel", SqlDbType.Int);
            param7.Value = product.ReorderLevel;
            command.Parameters.Add(param7);

            SqlParameter param8 = new SqlParameter("@Discontinued", SqlDbType.Bit);
            param8.Value = product.Discontinued;
            command.Parameters.Add(param8);

            int k = command.ExecuteNonQuery();
            command.Connection.Close();
            return k;
        }

     
        public static int Update(Product product)
        {
            string query = "update Products set " +
                "ProductName = @ProductName, " +
                "CategoryId = @CategoryId," +
                "SupplierId = @SupplierId," +
                "QuantityPerUnit = @QuantityPerUnit," +
                "UnitPrice = @UnitPrice," +
                "UnitsInStock = @UnitsInStock," +
                "ReorderLevel = @ReorderLevel," +
                "Discontinued = @Discontinued " + 
                "where ProductID = @productId";

            SqlCommand command = new SqlCommand(query, DBContext.GetConnection());

            SqlParameter param1 = new SqlParameter("@ProductName", SqlDbType.NVarChar);
            param1.Value = product.ProductName;
            command.Parameters.Add(param1);

            SqlParameter param2 = new SqlParameter("@CategoryId", SqlDbType.Int);
            param2.Value = product.CategoryId;
            command.Parameters.Add(param2);

            SqlParameter param3 = new SqlParameter("@SupplierId", SqlDbType.Int);
            param3.Value = product.SupplierId;
            command.Parameters.Add(param3);

            SqlParameter param4 = new SqlParameter("@QuantityPerUnit", SqlDbType.NVarChar);
            param4.Value = product.QuantityPerUnit;
            command.Parameters.Add(param4);

            SqlParameter param5 = new SqlParameter("@UnitPrice", SqlDbType.Money);
            param5.Value = product.UnitPrice;
            command.Parameters.Add(param5);

            SqlParameter param6 = new SqlParameter("@UnitsInStock", SqlDbType.Int);
            param6.Value = product.UnitsInStock;
            command.Parameters.Add(param6);

            SqlParameter param7 = new SqlParameter("@ReorderLevel", SqlDbType.Int);
            param7.Value = product.ReorderLevel;
            command.Parameters.Add(param7);

            SqlParameter param8 = new SqlParameter("@Discontinued", SqlDbType.Bit);
            param8.Value = product.Discontinued;
            command.Parameters.Add(param8);


            SqlParameter param9 = new SqlParameter("@productId", SqlDbType.Int);
            param9.Value = product.ProductId;
            command.Parameters.Add(param9);

            command.Connection.Open();
            int k = command.ExecuteNonQuery();
            command.Connection.Close();
            return k;
        }

        public static int Delete(int productId)
        {
            string query = "delete from [Order Details] where productId = " + productId.ToString();
            ExecuteNoQuery(query);
            query = "Delete from Products where productId = " + productId.ToString();
            return ExecuteNoQuery(query);
        }


    }
}
