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

        public string date_format { get; set; }
        public string RegionName { get; set; }

        public static Corporation Get(int corp_no)
        {
            DataRow row = CorporationDAO.GetById(corp_no);

            return new Corporation()
            {
                corp_no = corp_no,
                corp_name = row["corp_name"].ToString(),
                street = row["street"].ToString(),
            };
        }

        public static List<Corporation> All()
        {
            List<Corporation> courses = new List<Corporation>();

            DataTable dt = CorporationDAO.All();

            foreach (DataRow row in dt.Rows)
            {
                int rno = Convert.ToInt32(row["region_no"].ToString());

                string region_name = RegionDAO.Get(rno)["region_name"].ToString();

                DateTime time = Convert.ToDateTime(row["expr_dt"].ToString());

                courses.Add(new Corporation()
                {
                    corp_no = Convert.ToInt32(row["corp_no"].ToString()),
                    corp_name = row["corp_name"].ToString(),
                    expr_dt = time,
                    RegionName = region_name,
                    date_format = time.ToString("MM/dd/yyyy")
                });
            }

            return courses;
        }
    }
}