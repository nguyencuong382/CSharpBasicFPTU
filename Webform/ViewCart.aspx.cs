using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Webform.Entity;

namespace Webform
{
    public partial class ViewCart : System.Web.UI.Page
    {
        public void LoadPage()
        {
            Dictionary<int, int> carts = (Dictionary<int, int>)Session["cart"];

            if (carts != null)
            {
                List<Cart> cartItems = new List<Cart>();

                foreach (KeyValuePair<int, int> entry in carts)
                {
                    Product product = Product.Get(entry.Key);
                    cartItems.Add(new Cart()
                    {
                        Product = product,
                        Quality = entry.Value,
                        TotalPrice = product.UnitPrice * entry.Value
                    });
                }

                this.gvProduct.DataSource = cartItems;
               
            }
            this.gvProduct.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                LoadPage();
            }
        }

        protected void CellClicked(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName.Equals("Inc"))
            {

                Dictionary<int, int> carts = (Dictionary<int, int>)Session["cart"];
                if(carts != null)
                {
                    int productId = Convert.ToInt32(e.CommandArgument.ToString());
                    carts[productId] += 1;
                    Session["cart"] = carts;
                    LoadPage();
                }

            } else if(e.CommandName.Equals("Dec"))
            {

                Dictionary<int, int> carts = (Dictionary<int, int>)Session["cart"];
                if (carts != null)
                {
                    int productId = Convert.ToInt32(e.CommandArgument.ToString());

                    carts[productId]--;
                    if (carts[productId] == 0)
                    {
                        carts.Remove(productId);
                    }
                    Session["cart"] = carts;
                    LoadPage();
                }
            } else if (e.CommandName.Equals("Del"))
            {
                Dictionary<int, int> carts = (Dictionary<int, int>)Session["cart"];
                if (carts != null)
                {
                    int productId = Convert.ToInt32(e.CommandArgument.ToString());
                    carts.Remove(productId);
                    Session["cart"] = carts;
                    LoadPage();
                }
            }
        }
    }
}