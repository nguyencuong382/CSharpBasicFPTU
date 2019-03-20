using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webform.AppContext
{
    public class DBContext
    {
        public static SqlConnection GetConnection()
        {
            string url = ConfigurationManager.ConnectionStrings["NorthwindConnectionString"].ToString();
            return new SqlConnection(url);
        }
    }
}
