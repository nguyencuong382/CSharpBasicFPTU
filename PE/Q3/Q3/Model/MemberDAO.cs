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
    public class MemberDAO : DAO
    {
        public static DataTable All()
        {
            string query = "SELECT M.*, R.region_name FROM member M " +
                "INNER JOIN region R ON R.region_no = M.region_no";
            return ExecuteQueryTable(query);
        }

        public static DataRow Get(int member_no)
        {
            string query = "select M.*, R.region_name from member M " +
                            "INNER JOIN region R ON R.region_no = M.region_no " +
                            "where member_no = @member_no";
            SqlCommand command = new SqlCommand(query, DBContext.GetConnection());
            command.Parameters.Add(param("@member_no", SqlDbType.Int, member_no));
            return ExecuteQueryRow(command);
        }

        public static int Delete(int member_no)
        {
            string query = "delete from member where member_no = @member_no";
            SqlCommand command = new SqlCommand(query, DBContext.GetConnection());
            command.Parameters.Add(param("@member_no", SqlDbType.Int, member_no));
            return ExecuteNoQuery(command);
        }

        public static int Insert(Member member)
        {
            string query = "INSERT INTO member VALUES"
                + "            (@lastname"
                + "           ,@firstname"
                + "           ,null" //@middleinitial
                + "           ,''" //@street
                + "           ,''" //city
                + "           ,''" //@state_prov
                + "           ,''" //@country
                + "           ,''" //@mail_code
                + "           ,null" //@phone_no
                + "           ,null" //@photograph
                + "           ,@issue_dt"
                + "           ,@expr_dt"
                + "           ,@region_no"
                + "           ,@corp_no" //@corp_no
                + "           ,0" //@prev_balance
                + "           ,0" //@curr_balance
                + "           ,'')"; //@member_code

            SqlCommand command = new SqlCommand(query, DBContext.GetConnection());

            command.Parameters.Add(param("@lastname", SqlDbType.NVarChar, member.lastname));
            command.Parameters.Add(param("@firstname", SqlDbType.NVarChar, member.firstname));
            command.Parameters.Add(param("@issue_dt", SqlDbType.DateTime, member.issue_dt));
            command.Parameters.Add(param("@region_no", SqlDbType.Int, member.region_no));
            command.Parameters.Add(param("@corp_no", SqlDbType.Int, member.corp_no));
            command.Parameters.Add(param("@expr_dt", SqlDbType.DateTime, member.expr_dt));

            return ExecuteNoQuery(command);
        }

        public static int Edit(Member member)
        {
            string query = "UPDATE member\n"
                + "   SET [lastname] = @lastname\n"
                + "      ,[firstname] = @firstname\n"
                + "      ,[issue_dt] = @issue_dt\n"
                + "      ,[expr_dt] = @expr_dt\n"
                + " WHERE member_no = @member_no";

            SqlCommand command = new SqlCommand(query, DBContext.GetConnection());

            command.Parameters.Add(param("@lastname", SqlDbType.NVarChar, member.lastname));
            command.Parameters.Add(param("@firstname", SqlDbType.NVarChar, member.firstname));
            command.Parameters.Add(param("@issue_dt", SqlDbType.DateTime,member.issue_dt));
            command.Parameters.Add(param("@expr_dt", SqlDbType.DateTime, member.expr_dt));
            command.Parameters.Add(param("@member_no", SqlDbType.NVarChar, member.member_no));

            return ExecuteNoQuery(command);
        }
    }

   
}
