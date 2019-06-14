using App.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace App.Entity
{
    public class CourseRegistration
    {
        public string StudentID { get; set; }
        public string StudentName { get; set; }
        public bool Sex { get; set; }
        public string Subject { get; set; }
        public string Time { get; set; }
        public string Note { get; set; }

        public static CourseRegistration Get(string studentId)
        {
            DataRow row = CourseRegistrationDAO.Get(studentId);

            return new CourseRegistration()
            {
                StudentID = row["StudentID"].ToString(),
                StudentName = row["StudentName"].ToString(),
                Sex = Convert.ToBoolean(row["Sex"].ToString()),
                Subject = row["Subject"].ToString(),
                Time = row["Time"].ToString(),
                Note = row["Note"].ToString()
            };
        }

        public static List<CourseRegistration> All()
        {
            List<CourseRegistration> courses = new List<CourseRegistration>();

            DataTable dt = CourseRegistrationDAO.All();

            foreach(DataRow row in dt.Rows)
            {
                courses.Add(new CourseRegistration()
                {
                    StudentID = row["StudentID"].ToString(),
                    StudentName = row["StudentName"].ToString(),
                    Sex = Convert.ToBoolean(row["Sex"].ToString()),
                    Subject = row["Subject"].ToString(),
                    Time = row["Time"].ToString(),
                    Note = row["Note"].ToString()
                });
            }

            return courses;
        }

        
    }
}