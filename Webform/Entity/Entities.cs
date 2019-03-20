using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webform.Model;

namespace Webform.Entity
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Category(int id, string name)
        {
            Id = id;
            Name = name;
        }


        public static List<Category> GetAllCategories()
        {
            DataTable dt = new DataTable();
            dt = CategoryDAO.All();
            List<Category> categories = new List<Category>();
            foreach (DataRow dataRow in dt.Rows)
            {
                categories.Add(new Category(
                    Convert.ToInt32(dataRow["CategoryId"]),
                    dataRow["CategoryName"].ToString()
                    ));
            }
            return categories;
        }
    }


    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public int CategoryId { get; set; }
        public string QuantityPerUnit { get; set; }
        public double UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public int ReorderLevel { get; set; }
        public bool Discontinued { get; set; }
        public string CategoryName { get; set; }

        public Product() { }

        public static List<Product> All()
        {
            DataTable dt = new DataTable();
            dt = ProductDAO.All();
            List<Product> products = new List<Product>();

            foreach (DataRow dataRow in dt.Rows)
            {
                int categoryId = Convert.ToInt32(dataRow["CategoryId"]);
                int supplierId = Convert.ToInt32(dataRow["SupplierId"]);

                DataRow category = CategoryDAO.Get(categoryId);
                DataRow supplier = SupplierDAO.Get(supplierId);
                    
                    
                products.Add(new Product() {
                    ProductId = Convert.ToInt32(dataRow["ProductId"]),
                    ProductName = dataRow["ProductName"].ToString(),
                    CategoryName = category["CategoryName"].ToString(),
                    SupplierName = supplier["CompanyName"].ToString(),
                    QuantityPerUnit = dataRow["QuantityPerUnit"].ToString(),
                    UnitPrice = Convert.ToDouble(dataRow["UnitPrice"]),
                    UnitsInStock = Convert.ToInt32(dataRow["UnitsInStock"]),
                    ReorderLevel = Convert.ToInt32(dataRow["UnitsInStock"]),
                    Discontinued = Convert.ToBoolean(dataRow["Discontinued"])
                });
            }


            return products;
        }

        public static Product Get(int productId)
        {
            DataRow dataRow = ProductDAO.Get(productId);
            Product product;

            int categoryId = Convert.ToInt32(dataRow["CategoryId"]);
            int supplierId = Convert.ToInt32(dataRow["SupplierId"]);

            DataRow category = CategoryDAO.Get(categoryId);
            DataRow supplier = SupplierDAO.Get(supplierId);


            product = new Product()
            {
                ProductId = Convert.ToInt32(dataRow["ProductId"]),
                ProductName = dataRow["ProductName"].ToString(),
                CategoryId = categoryId,
                CategoryName = category["CategoryName"].ToString(),
                SupplierId = supplierId,
                SupplierName = supplier["CompanyName"].ToString(),
                QuantityPerUnit = dataRow["QuantityPerUnit"].ToString(),
                UnitPrice = Convert.ToDouble(dataRow["UnitPrice"]),
                UnitsInStock = Convert.ToInt32(dataRow["UnitsInStock"]),
                ReorderLevel = Convert.ToInt32(dataRow["UnitsInStock"]),
                Discontinued = Convert.ToBoolean(dataRow["Discontinued"])
            };

            return product;
        }
    }

    public class Order
    {
        public int OrderId { get; set; }
        public string CustomerID { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime RequiredDate { get; set; }
        public string ShipAddress { get; set; }
    }

    public class OrderDetail
    {
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public double UnitPrice { get; set; }
        public int Quantity { get; set; }
        public double Discount { get; set; }
    }

    public class Cart
    {
        public Product Product { get; set; }
        public int Quality { get; set; }
        public double TotalPrice { get; set; }
    }
}
