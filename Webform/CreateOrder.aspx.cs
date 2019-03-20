using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Webform.Entity;
using Webform.Model;

namespace Webform
{
    public partial class CreateOrder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.dlCustomers.DataSource = CustomerDAO.All();
                this.dlCustomers.DataTextField = "ContactName";
                this.dlCustomers.DataValueField = "CustomerID";
                this.dlCustomers.DataBind();

                DateTime dateTime = DateTime.UtcNow.Date;
                this.txtRequiredDate.Text = dateTime.ToString("dd/MM/yyyy");
                this.txtRequiredDate.DataBind();

                this.calendar.DataBind();



                //this.CustomValidator1.ControlToValidate = this.calendar.ID;
            }
        }

        protected void CustomValidator(object source, ServerValidateEventArgs args)
        {
            string date = calendar.SelectedDate.ToShortDateString();

            DateTime dateTime12 = DateTime.Parse(date);

            if(dateTime12 < DateTime.Today.AddDays(3))
            {
                args.IsValid = false;
            } else
            {
                args.IsValid = true;
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {

            this.CustomValidator1.Validate();

            if(this.validCart.IsValid && this.CustomValidator1.IsValid)
            {
                string requiredDate = calendar.SelectedDate.ToShortDateString();

                DateTime dateTime12 = DateTime.Parse(requiredDate);


                Order newOrder = new Order()
                {
                    CustomerID = this.dlCustomers.SelectedValue,
                    OrderDate = DateTime.Now,
                    RequiredDate = dateTime12,
                    ShipAddress = this.txtAddress.Text
                };

                int orderId = OrderDAO.Insert(newOrder);

                if (orderId > 0)
                {
                    Dictionary<int, int> carts = (Dictionary<int, int>)Session["cart"];

                    foreach(KeyValuePair<int, int> entry in carts)
                    {
                        Product product = Product.Get(entry.Key);

                        OrderDetail newOrderDetail = new OrderDetail()
                        {
                            OrderID = orderId,
                            ProductID = product.ProductId,
                            UnitPrice = product.UnitPrice,
                            Quantity = entry.Value,
                            Discount = 0,
                        };

                        OrderDetailDAO.Insert(newOrderDetail);
                    }

                    Session["cart"] = null;
                    Response.Write("<p class='success'> Create Order sucessfully</p>");
                }
                else
                {
                    Response.Write("<p class='err'> Create Order sucessfully</p>");
                }
            }
        }

        protected void validCart_ServerValidate(object source, ServerValidateEventArgs args)
        {
            Dictionary<int, int> carts = (Dictionary<int, int>)Session["cart"];

            if(carts == null || carts.Count == 0)
            {
                args.IsValid = false;
            } else
            {
                args.IsValid = true;
            }
        }
    }
}