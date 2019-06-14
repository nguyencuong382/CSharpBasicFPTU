using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace App.AppContext
{
    public class DBContext
    {
        public static SqlConnection GetConnection()
        {
            string url = ConfigurationManager.ConnectionStrings["PRN"].ToString();
            return new SqlConnection(url);
        }
    }
}