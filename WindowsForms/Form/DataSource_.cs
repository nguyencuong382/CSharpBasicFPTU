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
    public partial class DataSource_ : Form
    {
        public DataSource_()
        {
            InitializeComponent();
        }

        private void Loaded(object sender, EventArgs e)
        {
            linkProduct_LinkClicked(sender, e);
        }

        public void a(DataGridViewCellEventArgs e)
        {
            if(dataProduct.Columns[e.ColumnIndex].Name == "delCol")
            {
                int productId = Convert.ToInt32(dataProduct.Rows[e.RowIndex].Cells[0].Value);
                
            } else if (dataProduct.Columns[e.ColumnIndex].Name == "editCol")
            {

            }
        }

        public void EditProduct(int productId)
        {
            Product product = Product.Get(productId);
            EditProduct editProduct = new EditProduct(product);
            editProduct.ShowDialog();

            if(editProduct.IsEdit)
            {
                loadProduct();
            }
        }

        public void loadProduct()
        {
            dataProduct.AutoGenerateColumns = false;
            dataProduct.DataSource = Product.All();


            dataProduct.Columns.Clear();

            dataProduct.Columns.Add(getDataGridViewTextColumn("ProductId"));
            dataProduct.Columns.Add(getDataGridViewTextColumn("ProductName"));
            dataProduct.Columns.Add(getDataGridViewTextColumn("CategoryName"));
            dataProduct.Columns.Add(getDataGridViewTextColumn("SupplierName"));
            dataProduct.Columns.Add(getDataGridViewTextColumn("QuantityPerUnit"));
            dataProduct.Columns.Add(getDataGridViewTextColumn("UnitPrice"));
            dataProduct.Columns.Add(getDataGridViewTextColumn("UnitsInStock"));
            dataProduct.Columns.Add(getDataGridViewTextColumn("ReorderLevel"));

            DataGridViewCheckBoxColumn box = new DataGridViewCheckBoxColumn();
            box.HeaderText = "Discontinued";
            box.Name = "Discontinued";
            box.DataPropertyName = "Discontinued";
            box.ReadOnly = true;

            dataProduct.Columns.Add(box);

            dataProduct.Columns.Add(getDataGridViewButtonColumn("Delete"));
            dataProduct.Columns.Add(getDataGridViewButtonColumn("Edit"));
        }

        private void dataProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dataProduct.Columns[e.ColumnIndex].Name;
            int productId = Convert.ToInt32(dataProduct.Rows[e.RowIndex].Cells[0].Value);

            switch (colName)
            {
                case "Delete":
                    {
                        DialogResult result = MessageBox.Show("Are you sure delete this product?", "Delete product", MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            int count = ProductDAO.Delete(productId);
                            MessageBox.Show(count.ToString() + " product(s) was deleted.");
                            loadProduct();
                        }
                        break;
                    }
                case "Edit":
                    {
                        
                        EditProduct(productId);
                        break;
                    }
                default:
                    break;
            }
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            AddProduct addProduct = new AddProduct();
            addProduct.ShowDialog();
            Product newProduct = addProduct.getProduct();

            if (newProduct != null)
            {
                loadProduct();
            }
        }

        private void linkCategory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            dataProduct.AutoGenerateColumns = true;
            dataProduct.Columns.Clear();
            dataProduct.DataSource = CategoryDAO.All();
            btnAddProduct.Enabled = false;

        }

        private void linkSupplier_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            dataProduct.AutoGenerateColumns = true;
            dataProduct.Columns.Clear();
            dataProduct.DataSource = SupplierDAO.All();
            btnAddProduct.Enabled = false;

        }

        private void linkOrder_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            dataProduct.AutoGenerateColumns = true;
            dataProduct.Columns.Clear();
            dataProduct.DataSource = OrderDAO.All();
            dataProduct.Columns["EmployeeID"].Visible = false;
            btnAddProduct.Enabled = false;

        }

        public DataGridViewTextBoxColumn getDataGridViewTextColumn(string colName)
        {
            DataGridViewTextBoxColumn gridView = new DataGridViewTextBoxColumn();
            gridView.HeaderText = colName;
            gridView.Name = colName;
            gridView.DataPropertyName = colName;

            return gridView;
        }

        public DataGridViewButtonColumn getDataGridViewButtonColumn(string colName)
        {
            DataGridViewButtonColumn gridView = new DataGridViewButtonColumn();
            gridView.Name = colName;
            gridView.Text = colName;
            gridView.UseColumnTextForButtonValue = true;
            return gridView;
        }

        private void linkProduct_LinkClicked(object sender, EventArgs e)
        {
            loadProduct();
            btnAddProduct.Enabled = true;

        }
    }
}
