using App.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace App.Entity
{
    public class Region
    {
        public int region_no { get; set; }
        public string region_name { get; set; }
        public string street { get; set; }
        public string city { get; set; }
        public string state_prov { get; set; }
        public string country { get; set; }
        public string mail_code { get; set; }
        public string phone_no { get; set; }
        public string region_code { get; set; }

        public static Region Get(int region_no)
        {
            DataRow row = RegionDAO.Get(region_no);

            return new Region()
            {
                region_no = region_no,
            };
        }

        public static List<Region> All()
        {
            List<Region> regions = new List<Region>();

            DataTable dt = RegionDAO.All();

            foreach (DataRow row in dt.Rows)
            {
                Region m = new Region()
                {
                    region_no = Convert.ToInt32(row["region_no"].ToString())
                };

                regions.Add(m);
            }

            return regions;
        }
    }
}
