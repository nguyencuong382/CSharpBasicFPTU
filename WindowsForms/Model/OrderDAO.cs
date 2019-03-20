using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsForms.Model
{
    public class OrderDAO : _DAO
    {
        public static DataTable All()
        {
            string query = "select * from orders";
            return ExecuteQueryTable(query);
        }
    }
}
