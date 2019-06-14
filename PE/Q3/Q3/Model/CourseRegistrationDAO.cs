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
    public class CourseRegistrationDAO : DAO
    {
        public static DataTable All()
        {
            string query = "SELECT * FROM CourseRegistration";
            return ExecuteQueryTable(query);
        }

        public static DataRow Get(string studentId)
        {
            string query = "SELECT * FROM CourseRegistration WHERE StudentID = @studentId";

            SqlCommand command = new SqlCommand(query, DBContext.GetConnection());
            command.Parameters.Add(param("@studentId", SqlDbType.VarChar, studentId));
            return ExecuteQueryRow(command);
        }

        public static int Insert(CourseRegistration course)
        {
            string query = "INSERT INTO CourseRegistration VALUES"
                + "           (@StudentID"
                + "           ,@StudentName"
                + "           ,@Sex"
                + "           ,@Subject"
                + "           ,@Time"
                + "           ,@Note)";
            SqlCommand command = new SqlCommand(query, DBContext.GetConnection());

            command.Parameters.Add(param("@StudentID", SqlDbType.VarChar, course.StudentID));
            command.Parameters.Add(param("@StudentName", SqlDbType.NVarChar, course.StudentName));
            command.Parameters.Add(param("@Sex", SqlDbType.Bit, course.Sex));
            command.Parameters.Add(param("@Subject", SqlDbType.VarChar, course.Subject));
            command.Parameters.Add(param("@Time", SqlDbType.NVarChar, course.Time));
            command.Parameters.Add(param("@Note", SqlDbType.Text, course.Note));

            return ExecuteNoQuery(command);
        }

        public static int Edit(CourseRegistration course)
        {
            string query = "UPDATE CourseRegistration"
                + "   SET [StudentID] = @StudentID"
                + "      ,[S tudentName] = @StudentName"
                + "      ,[Sex] = @Sex"
                + "      ,[Subject] = @Subject"
                + "      ,[Time] = @Time"
                + "      ,[Note] = @Note"
                + " WHERE StudentID = @StudentID";

            SqlCommand command = new SqlCommand(query, DBContext.GetConnection());

            command.Parameters.Add(param("@StudentID", SqlDbType.VarChar, course.StudentID));
            command.Parameters.Add(param("@StudentName", SqlDbType.NVarChar, course.StudentName));
            command.Parameters.Add(param("@Sex", SqlDbType.Bit, course.Sex));
            command.Parameters.Add(param("@Subject", SqlDbType.VarChar, course.Subject));
            command.Parameters.Add(param("@Time", SqlDbType.NVarChar, course.Time));
            command.Parameters.Add(param("@Note", SqlDbType.Text, course.Note));

            return ExecuteNoQuery(command);
        }
    }
}