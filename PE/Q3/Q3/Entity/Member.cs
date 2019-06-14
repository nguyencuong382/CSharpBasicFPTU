using App.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace App.Entity
{
    public class Member
    {
        public int member_no { get; set; }
        public string lastname { get; set; }
        public string firstname { get; set; }
        public string middleinitial { get; set; }
        public string street { get; set; }
        public string city { get; set; }
        public string state_prov { get; set; }
        public string country { get; set; }
        public string mail_code { get; set; }
        public string phone_no { get; set; }
        public string photograph { get; set; }

        public DateTime issue_dt { get; set; }
        public DateTime expr_dt { get; set; }

        public int region_no { get; set; }
        public int corp_no { get; set; }
        public double prev_balance { get; set; }
        public double curr_balance { get; set; }
        public string member_code { get; set; }

        public string RegionName { get; set; }

        public static Member Get(int member_no)
        {
            DataRow row = MemberDAO.Get(member_no);
            
            return new Member()
            {
                member_no = member_no,
                lastname = row["lastname"].ToString(),
                firstname = row["firstname"].ToString(),
                issue_dt = Convert.ToDateTime(row["issue_dt"].ToString()),
                expr_dt = Convert.ToDateTime(row["expr_dt"].ToString()),
                RegionName = row["region_name"].ToString(),
            };
        }

        public static List<Member> All()
        {
            List<Member> members = new List<Member>();

            DataTable dt = MemberDAO.All();

            foreach(DataRow row in dt.Rows)
            {
                Member m = new Member()
                {
                    member_no = Convert.ToInt32(row["member_no"].ToString()),
                    lastname = row["lastname"].ToString(),
                    firstname = row["firstname"].ToString(),
                    issue_dt = Convert.ToDateTime(row["issue_dt"].ToString()),
                    expr_dt = Convert.ToDateTime(row["expr_dt"].ToString()),
                    RegionName = row["region_name"].ToString(),
                };

                members.Add(m);
            }

            return members;
        }

       
    }
}
