using App.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace App.Entity
{
    public class TestResult
    {
        public string StudentID { get; set; }
        public string StudentName { get; set; }
        public string Subject { get; set; }
        public string TestType { get; set; }
        public DateTime Date { get; set; }
        public double Mark { get; set; }

        public static TestResult Get(string studentId)
        {
            DataRow row = TestResultDAO.Get(studentId);

            return new TestResult()
            {
                StudentID = row["StudentID"].ToString(),
                StudentName = row["StudentName"].ToString(),
                Subject = row["Subject"].ToString(),
                TestType = row["TestType"].ToString(),
                Date = Convert.ToDateTime(row["Date"].ToString()),
                Mark = Convert.ToDouble(row["Mark"].ToString())
            };
        }

        public static List<TestResult> All()
        {
            List<TestResult> results = new List<TestResult>();

            DataTable dt = CourseRegistrationDAO.All();

            foreach (DataRow row in dt.Rows)
            {
                results.Add(new TestResult()
                {
                    StudentID = row["StudentID"].ToString(),
                    StudentName = row["StudentName"].ToString(),
                    Subject = row["Subject"].ToString(),
                    TestType = row["TestType"].ToString(),
                    Date = Convert.ToDateTime(row["Date"].ToString()),
                    Mark = Convert.ToDouble(row["Mark"].ToString())
                });
            }

            return results;
        }
    }
}