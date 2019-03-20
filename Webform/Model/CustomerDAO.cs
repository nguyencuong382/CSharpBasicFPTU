using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Webform.Model
{
    public class CustomerDAO : _DAO
    {
        public static DataTable All()
        {
            string query = "select * from Customers";
            return ExecuteQueryTable(query);
        }
    }
}