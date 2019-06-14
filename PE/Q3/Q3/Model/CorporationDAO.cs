using App.AppContext;
using App.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace App.Model
{
    public class CorporationDAO : DAO
    {
        public static DataTable All()
        {
            string query = "Select * from corporation";
            return ExecuteQueryTable(query);
        }

        public static DataTable Get(int region_no)
        {
            string query = "select * from corporation where region_no = @region_no";
            SqlCommand sqlCommand = new SqlCommand(query, DBContext.GetConnection());
            sqlCommand.Parameters.Add(param("@region_no", SqlDbType.NVarChar, region_no));
            return ExecuteQueryTable(sqlCommand);
        }

        public static DataRow GetById(int corp_no)
        {
            string query = "select * from corporation where corp_no = @corp_no";
            SqlCommand sqlCommand = new SqlCommand(query, DBContext.GetConnection());
            sqlCommand.Parameters.Add(param("@corp_no", SqlDbType.NVarChar, corp_no));
            return ExecuteQueryRow(sqlCommand);
        }

        public static int Insert(Corporation corporation)
        {
            string query = "UPDATE corporation\n"
                + "   SET [corp_name] = @corp_name\n"
                + "      ,[street] = @street\n"
                + "      ,[city] = @city\n"
                + "      ,[state_prov] = @state_prov\n"
                + "      ,[country] = @country\n"
                + "      ,[mail_code] = @mail_code\n"
                + "      ,[phone_no] = @phone_no\n"
                + "      ,[expr_dt] = @expr_dt\n"
                + "      ,[region_no] = @region_no\n"
                + "      ,[corp_code] = @corp_code\n"
                + " WHERE corp_no = @corp_no"; ;


            SqlCommand command = new SqlCommand(query, DBContext.GetConnection());

            command.Parameters.Add(param("@corp_name", SqlDbType.VarChar, corporation.corp_name));
            command.Parameters.Add(param("@street", SqlDbType.VarChar, corporation.street));
            command.Parameters.Add(param("@city", SqlDbType.VarChar, corporation.city));
            command.Parameters.Add(param("@state_prov", SqlDbType.Char, corporation.state_prov));
            command.Parameters.Add(param("@country", SqlDbType.Char, corporation.country));
            command.Parameters.Add(param("@mail_code", SqlDbType.Char, corporation.mail_code));
            command.Parameters.Add(param("@phone_no", SqlDbType.Char, corporation.phone_no));
            command.Parameters.Add(param("@expr_dt", SqlDbType.DateTime, corporation.expr_dt));
            command.Parameters.Add(param("@region_no", SqlDbType.Int, corporation.region_no));
            command.Parameters.Add(param("@corp_code", SqlDbType.Char, corporation.corp_code));
            command.Parameters.Add(param("@corp_no", SqlDbType.Int, corporation.corp_no));

            return ExecuteNoQuery(command);

        }

        public static int Edit(Corporation corporation)
        {
            string query = "INSERT INTO corporation\n"
                + "     VALUES\n"
                + "           (@corp_name\n"
                + "           ,@street\n"
                + "           ,@city\n"
                + "           ,@state_prov\n"
                + "           ,@country\n"
                + "           ,@mail_code\n"
                + "           ,@phone_no\n"
                + "           ,@expr_dt\n"
                + "           ,@region_no\n"
                + "           ,@corp_code)";


            SqlCommand command = new SqlCommand(query, DBContext.GetConnection());

            command.Parameters.Add(param("@corp_name", SqlDbType.VarChar, corporation.corp_name));
            command.Parameters.Add(param("@street", SqlDbType.VarChar, corporation.street));
            command.Parameters.Add(param("@city", SqlDbType.VarChar, corporation.city));
            command.Parameters.Add(param("@state_prov", SqlDbType.Char, corporation.state_prov));
            command.Parameters.Add(param("@country", SqlDbType.Char, corporation.country));
            command.Parameters.Add(param("@mail_code", SqlDbType.Char, corporation.mail_code));
            command.Parameters.Add(param("@phone_no", SqlDbType.Char, corporation.phone_no));
            command.Parameters.Add(param("@expr_dt", SqlDbType.DateTime, corporation.expr_dt));
            command.Parameters.Add(param("@region_no", SqlDbType.Int, corporation.region_no));
            command.Parameters.Add(param("@corp_code", SqlDbType.Char, corporation.corp_code));

            return ExecuteNoQuery(command);
        }
    }
}