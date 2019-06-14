using App.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Q3
{
    public partial class CourseRegistration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.lbSubject.Items.Insert(0, "PRF192");
                this.lbSubject.Items.Insert(1, "PRO201");
                this.lbSubject.Items.Insert(2, "DBI201");
                this.lbSubject.Items.Insert(3, "PRN292");
                this.lbSubject.Items.Insert(4, "PRN321");

                this.lbSubject.SelectedIndex = 0;

                this.lbSubject.DataBind();

                this.dlTime.Items.Insert(0, "7h:00 - 9h:00");
                this.dlTime.Items.Insert(1, "9h:30 - 11h:30");
                this.dlTime.Items.Insert(2, "13h:00 - 13h:00");
                this.dlTime.Items.Insert(3, "13h:30 - 15h:30");

                this.dlTime.SelectedIndex = 0;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            App.Entity.CourseRegistration course = new App.Entity.CourseRegistration()
            {
                StudentID = this.txtStudentId.Text,
                StudentName = this.txtStudentName.Text,
                Sex = this.rdMale.Checked,
                Subject = this.lbSubject.SelectedValue,
                Time = this.dlTime.SelectedValue,
                Note = this.txtNote.Text
            };

            if(CourseRegistrationDAO.Insert(course) > 0)
            {
                Response.Write("Added sucessful");
            }


        }
    }
}