using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsForms.Entity;
using WindowsForms.Model;

namespace WindowsForms
{
    public partial class EditProduct : Form
    {
        public Product Product { get; set; }
        
        public EditProduct(Product product)
        {
            InitializeComponent();
            Product = product;
            Init();
        }

        public void Init()
        {
            IsEdit = false;
            cbCategory.DataSource = CategoryDAO.All();
            cbCategory.DisplayMember = "CategoryName";
            cbCategory.ValueMember = "CategoryID";
            cbCategory.SelectedValue = Product.CategoryId;

            cbSupplier.DataSource = SupplierDAO.All();
            cbSupplier.DisplayMember = "CompanyName";
            cbSupplier.ValueMember = "SupplierID";
            cbSupplier.SelectedValue = Product.SupplierId;

            this.txtProductId.Text = Product.ProductId.ToString();
            this.txtProductName.Text = Product.ProductName;
            this.txtQantity.Text = Product.QuantityPerUnit.ToString();
            this.txtReorder.Text = Product.ReorderLevel.ToString();
            this.txtUnitPrice.Text = Product.UnitPrice.ToString();
            this.txtUnitsInStock.Text = Product.UnitsInStock.ToString();

            if(Product.Discontinued)
            {
                this.btnYesDiscontinued.Checked = true;
            } else
            {
                this.bntNo.Checked = true;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string productName = txtProductName.Text.Trim().ToString();

            if (string.IsNullOrEmpty(productName))
            {
                MessageBox.Show("Product name is empty!");
                txtProductName.Focus();
                return;
            }

            int categoryId = Convert.ToInt32(cbCategory.SelectedValue.ToString());
            int supplierId = Convert.ToInt32(cbSupplier.SelectedValue.ToString());

            string quantityPerUnit = txtQantity.Text;
            if (string.IsNullOrEmpty(quantityPerUnit))
            {
                MessageBox.Show("Q0!");
                txtQantity.Focus();
                return;
            }


            double price;
            bool result = double.TryParse(txtUnitPrice.Text, out price);
            if (!result || price < 0)
            {
                MessageBox.Show("Price must be negative number!");
                txtUnitPrice.Focus();
                return;
            }

            int uintsInStock;
            result = int.TryParse(txtUnitsInStock.Text, out uintsInStock);
            if (!result || uintsInStock < 0)
            {
                MessageBox.Show("UnitsInStock must be negative integer!");
                txtUnitsInStock.Focus();
                return;
            }

            int reorderLevel;
            result = int.TryParse(txtReorder.Text, out reorderLevel);
            if (!result || reorderLevel < 0)
            {
                MessageBox.Show("ReorderLevel must be negative integer!");
                txtReorder.Focus();
                return;
            }

            bool discontinued = btnYesDiscontinued.Checked;

            Product.ProductName = productName;
            Product.CategoryId = categoryId;
            Product.SupplierId = supplierId;
            Product.QuantityPerUnit = quantityPerUnit;
            Product.UnitPrice = price;
            Product.UnitsInStock = uintsInStock;
            Product.ReorderLevel = reorderLevel;
            Product.Discontinued = discontinued;

            if (ProductDAO.Update(Product) > 0)
            {
                IsEdit = true;
                MessageBox.Show("Update Product Sucessfully!");
            }

            this.Dispose();

        }

        public bool IsEdit { get; set; }
    }
}
