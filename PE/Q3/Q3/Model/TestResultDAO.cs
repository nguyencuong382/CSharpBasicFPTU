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
    public class TestResultDAO : DAO
    {
        public static DataTable All()
        {
            string query = "Select * from corporation";
            return ExecuteQueryTable(query);
        }

        public static DataRow Get(string studentId)
        {
            string query = "select * from TestResult where StudentID = @studentId";

            SqlCommand command = new SqlCommand(query, DBContext.GetConnection());
            command.Parameters.Add(param("@studentId", SqlDbType.VarChar, studentId));
            return ExecuteQueryRow(command);
        }

        public static int Insert(TestResult testResult)
        {
            string query = "INSERT INTO TestResult VALUES"
                + "           (@StudentID,"
                + "           ,@StudentName,"
                + "           ,@Subject,"
                + "           ,@TestType,"
                + "           ,@Date,"
                + "           ,@Mark)"; ;
            SqlCommand command = new SqlCommand(query, DBContext.GetConnection());

            command.Parameters.Add(param("@StudentID", SqlDbType.VarChar, testResult.StudentID));
            command.Parameters.Add(param("@StudentName", SqlDbType.NVarChar, testResult.StudentName));
            command.Parameters.Add(param("@Subject", SqlDbType.VarChar, testResult.Subject));
            command.Parameters.Add(param("@TestType", SqlDbType.Char, testResult.TestType));
            command.Parameters.Add(param("@Date", SqlDbType.NVarChar, testResult.Date));
            command.Parameters.Add(param("@Mark", SqlDbType.Float, testResult.Mark));

            return ExecuteNoQuery(command);
        }

        public static int Edit(TestResult testResult)
        {
            string query = "UPDATE TestResult"
                + "   SET [StudentID] = @StudentID"
                + "      ,[StudentName] = @StudentName"
                + "      ,[Subject] = @Subject"
                + "      ,[TestType] = @TestType"
                + "      ,[Date] = @Date"
                + "      ,[Mark] = @Mark"
                + " WHERE StudentID = @StudentID";

            SqlCommand command = new SqlCommand(query, DBContext.GetConnection());

            command.Parameters.Add(param("@StudentID", SqlDbType.VarChar, testResult.StudentID));
            command.Parameters.Add(param("@StudentName", SqlDbType.NVarChar, testResult.StudentName));
            command.Parameters.Add(param("@Subject", SqlDbType.VarChar, testResult.Subject));
            command.Parameters.Add(param("@TestType", SqlDbType.Char, testResult.TestType));
            command.Parameters.Add(param("@Date", SqlDbType.NVarChar, testResult.Date));
            command.Parameters.Add(param("@Mark", SqlDbType.Float, testResult.Mark));


            return ExecuteNoQuery(command);
        }
    }
}