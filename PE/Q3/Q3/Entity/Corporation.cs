using App.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace App.Entity
{
    public class Corporation
    {
        public int corp_no { get; set; }
        public string corp_name { get; set; }
        public string street { get; set; }
        public string city { get; set; }
        public string state_prov { get; set; }
        public string country { get; set; }
        public string mail_code { get; set; }
        public string phone_no { get; set; }
        public DateTime expr_dt { get; set; }
        public int region_no { get; set; }
        public string corp_code { get; set; }

        public static Corporation Get(int corp_no)
        {
            DataRow row = CorporationDAO.GetById(corp_no);

            return new Corporation()
            {
                corp_no = corp_no,
            };
        }

        public static List<Corporation> All()
        {
            List<Corporation> courses = new List<Corporation>();

            DataTable dt = CorporationDAO.All();

            foreach (DataRow row in dt.Rows)
            {
                courses.Add(new Corporation()
                {
                });
            }

            return courses;
        }
    }
}