using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Webform.Entity;
using Webform.Model;

namespace Webform
{
    public partial class _default : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                DataTable dt = CategoryDAO.All();
                this.dtCategory.DataSource = dt;
                
                gvProduct.PageSize = Convert.ToInt32(ConfigurationManager.AppSettings["PageSize"].ToString());
                gvProduct.PageIndex = 0;
                //this.dtCategory.DataTextField = "CategoryName";
                //this.dtCategory.DataValueField = "CategoryID";
                //this.dtCategory.DataMember = "CategoryName";
                //this.dtCategory.DataKeyField = "CategoryName";
                this.dtCategory.DataBind();

                int categoryId = Convert.ToInt32(dt.Rows[0]["CategoryID"].ToString());
                this.gvProduct.DataSource = ProductDAO.GetByCategory(categoryId);
                this.gvProduct.DataBind();

                Session["CategoryID"] = categoryId;

                var lb = (LinkButton)dtCategory.Items[0].FindControl("lbCategory");
                lb.CssClass = "active";

                //Response.Write(this.gvProduct.PageSize);
            }

        }
      
        protected void gvProduct_SelectedIndexChanged(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName.Equals("AddToCart"))
            {
                int productID = Convert.ToInt32(e.CommandArgument.ToString());

                Dictionary<int, int> carts = (Dictionary<int, int>)Session["cart"];

                int currentQuality = 0;

                if(carts == null)
                {
                    carts = new Dictionary<int, int>();
                } else
                {
                    carts.TryGetValue(productID, out currentQuality);
                }

                currentQuality++;

                if (carts.ContainsKey(productID))
                {
                    carts[productID] = currentQuality;
                } else
                {
                    carts.Add(productID, currentQuality);
                }

                
                Session["cart"] = carts;

                //Response.Write("<p>Added " + currentQuality);
            }
        }

        protected void PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            // get current page
            gvProduct.PageIndex = e.NewPageIndex;
            gvProduct.DataSource = ProductDAO.GetByCategory(Convert.ToInt32(Session["CategoryID"]));
            gvProduct.DataBind();
        }

        public int ItemOrder { get; set; }


        protected void CategoryItemCommand(object source, DataListCommandEventArgs e)
        {
            
            //Response.Write(e.Item.ItemIndex);
        }

        protected void lbCategory_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dtCategory.Items.Count; i++)
            {
                var lb = (LinkButton)dtCategory.Items[i].FindControl("lbCategory");
                lb.CssClass = "";
            }

            LinkButton lbtn = (LinkButton)sender;

            if (lbtn.CommandName.Equals("CategoryID"))
            {
                lbtn.CssClass += " active";
                int categoryId = Convert.ToInt32(lbtn.CommandArgument);
                this.gvProduct.DataSource = ProductDAO.GetByCategory(categoryId);
                this.gvProduct.PageIndex = 0;
                this.gvProduct.DataBind();

                Session["CategoryID"] = categoryId;
            }
    }
    }
}