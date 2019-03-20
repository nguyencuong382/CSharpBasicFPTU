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
    public partial class AddProduct : Form
    {
        private Product newProduct;

        public AddProduct()
        {
            InitializeComponent();

            cbCategory.DataSource = CategoryDAO.All();
            cbCategory.DisplayMember = "CategoryName";
            cbCategory.ValueMember = "CategoryID";

            cbSupplier.DataSource = SupplierDAO.All();
            cbSupplier.DisplayMember = "CompanyName";
            cbSupplier.ValueMember = "SupplierID";
        }

        private void btnAdd_Click(object sender, EventArgs e)
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
                MessageBox.Show("uantity per Unit is empty!");
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

            newProduct = new Product() {
                ProductId = 0,
                ProductName = productName,
                CategoryId = categoryId,
                SupplierId = supplierId,
                QuantityPerUnit = quantityPerUnit,
                UnitPrice = price,
                UnitsInStock = uintsInStock,
                ReorderLevel = reorderLevel,
                Discontinued = discontinued
            };

            if(ProductDAO.Insert(newProduct) > 0)
            {
                MessageBox.Show("Insert Product Sucessfully!");
                this.Dispose();
            }
        }

        private void btnCacel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        public Product getProduct()
        {
            return this.newProduct;
        }
    }
}
