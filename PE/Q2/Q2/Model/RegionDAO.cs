using App.AppContext;
using App.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace App.Model
{
    public class RegionDAO : DAO
    {
        public static DataTable All()
        {
            string query = "select * from region";
            return ExecuteQueryTable(query);
        }

        public static DataRow Get(int region_no)
        {
            string query = "select * from region where region_no = @region_no";
            SqlCommand sqlCommand = new SqlCommand(query, DBContext.GetConnection());
            sqlCommand.Parameters.Add(param("@region_no", SqlDbType.NVarChar,region_no));
            return ExecuteQueryRow(sqlCommand);
        }

        public static int Edit(Region region)
        {
            string query = "UPDATE region\n"
                + "   SET [region_name] = @region_name\n"
                + "      ,[street] = @street\n"
                + "      ,[city] = @city\n"
                + "      ,[state_prov] = @state_prov\n"
                + "      ,[country] = @country\n"
                + "      ,[mail_code] = @mail_code\n"
                + "      ,[phone_no] = @phone_no\n"
                + "      ,[region_code] = @region_code\n"
                + " WHERE region_no = @region_no";

            SqlCommand command = new SqlCommand(query, DBContext.GetConnection());

            command.Parameters.Add(param("@region_name", SqlDbType.VarChar, region.region_name));
            command.Parameters.Add(param("@street", SqlDbType.VarChar, region.street));
            command.Parameters.Add(param("@city", SqlDbType.VarChar, region.city));
            command.Parameters.Add(param("@state_prov", SqlDbType.Char, region.state_prov));
            command.Parameters.Add(param("@country", SqlDbType.Char, region.country));
            command.Parameters.Add(param("@mail_code", SqlDbType.Char, region.mail_code));
            command.Parameters.Add(param("@phone_no", SqlDbType.Char, region.phone_no));
            command.Parameters.Add(param("@region_code", SqlDbType.Char, region.region_code));

            return ExecuteNoQuery(command);
        }

        public static int Insert(Region region)
        {
            string query = "INSERT INTO region\n"
                + "     VALUES\n"
                + "           (@region_name\n"
                + "           ,@street\n"
                + "           ,@city\n"
                + "           ,@state_prov\n"
                + "           ,@country\n"
                + "           ,@mail_code\n"
                + "           ,@phone_no\n"
                + "           ,@region_code)";

            SqlCommand command = new SqlCommand(query, DBContext.GetConnection());

            command.Parameters.Add(param("@region_name", SqlDbType.VarChar, region.region_name));
            command.Parameters.Add(param("@street", SqlDbType.VarChar, region.street));
            command.Parameters.Add(param("@city", SqlDbType.VarChar, region.city));
            command.Parameters.Add(param("@state_prov", SqlDbType.Char, region.state_prov));
            command.Parameters.Add(param("@country", SqlDbType.Char, region.country));
            command.Parameters.Add(param("@mail_code", SqlDbType.Char, region.mail_code));
            command.Parameters.Add(param("@phone_no", SqlDbType.Char, region.phone_no));
            command.Parameters.Add(param("@region_code", SqlDbType.Char, region.region_code));

            return ExecuteNoQuery(command);
        }
    }
}
