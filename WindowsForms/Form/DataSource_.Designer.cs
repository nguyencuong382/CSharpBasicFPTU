namespace WindowsForms
{
    partial class DataSource_
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.autoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataProduct = new System.Windows.Forms.DataGridView();
            this.btnAddProduct = new System.Windows.Forms.Button();
            this.linkCategory = new System.Windows.Forms.LinkLabel();
            this.linkSupplier = new System.Windows.Forms.LinkLabel();
            this.linkProduct = new System.Windows.Forms.LinkLabel();
            this.linkOrder = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.autoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataProduct)).BeginInit();
            this.SuspendLayout();
            // 
            // autoBindingSource
            // 
            this.autoBindingSource.DataSource = typeof(MainConsole.Auto);
            // 
            // dataProduct
            // 
            this.dataProduct.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataProduct.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataProduct.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataProduct.Location = new System.Drawing.Point(13, 31);
            this.dataProduct.Name = "dataProduct";
            this.dataProduct.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dataProduct.Size = new System.Drawing.Size(592, 220);
            this.dataProduct.TabIndex = 1;
            this.dataProduct.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataProduct_CellContentClick);
            // 
            // btnAddProduct
            // 
            this.btnAddProduct.Location = new System.Drawing.Point(13, 255);
            this.btnAddProduct.Name = "btnAddProduct";
            this.btnAddProduct.Size = new System.Drawing.Size(75, 23);
            this.btnAddProduct.TabIndex = 2;
            this.btnAddProduct.Text = "Add Product";
            this.btnAddProduct.UseVisualStyleBackColor = true;
            this.btnAddProduct.Click += new System.EventHandler(this.btnAddProduct_Click);
            // 
            // linkCategory
            // 
            this.linkCategory.AutoSize = true;
            this.linkCategory.Location = new System.Drawing.Point(12, 9);
            this.linkCategory.Name = "linkCategory";
            this.linkCategory.Size = new System.Drawing.Size(49, 13);
            this.linkCategory.TabIndex = 3;
            this.linkCategory.TabStop = true;
            this.linkCategory.Text = "Category";
            this.linkCategory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkCategory_LinkClicked);
            // 
            // linkSupplier
            // 
            this.linkSupplier.AutoSize = true;
            this.linkSupplier.Location = new System.Drawing.Point(77, 9);
            this.linkSupplier.Name = "linkSupplier";
            this.linkSupplier.Size = new System.Drawing.Size(45, 13);
            this.linkSupplier.TabIndex = 4;
            this.linkSupplier.TabStop = true;
            this.linkSupplier.Text = "Supplier";
            this.linkSupplier.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkSupplier_LinkClicked);
            // 
            // linkProduct
            // 
            this.linkProduct.AutoSize = true;
            this.linkProduct.Location = new System.Drawing.Point(147, 9);
            this.linkProduct.Name = "linkProduct";
            this.linkProduct.Size = new System.Drawing.Size(44, 13);
            this.linkProduct.TabIndex = 5;
            this.linkProduct.TabStop = true;
            this.linkProduct.Text = "Product";
            this.linkProduct.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkProduct_LinkClicked);
            // 
            // linkOrder
            // 
            this.linkOrder.AutoSize = true;
            this.linkOrder.Location = new System.Drawing.Point(217, 9);
            this.linkOrder.Name = "linkOrder";
            this.linkOrder.Size = new System.Drawing.Size(33, 13);
            this.linkOrder.TabIndex = 6;
            this.linkOrder.TabStop = true;
            this.linkOrder.Text = "Order";
            this.linkOrder.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkOrder_LinkClicked);
            // 
            // DataSource_
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 283);
            this.Controls.Add(this.linkOrder);
            this.Controls.Add(this.linkProduct);
            this.Controls.Add(this.linkSupplier);
            this.Controls.Add(this.linkCategory);
            this.Controls.Add(this.btnAddProduct);
            this.Controls.Add(this.dataProduct);
            this.Name = "DataSource_";
            this.Text = "DataSource_";
            this.Load += new System.EventHandler(this.Loaded);
            ((System.ComponentModel.ISupportInitialize)(this.autoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataProduct)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.BindingSource autoBindingSource;
        private System.Windows.Forms.DataGridView dataProduct;
        private System.Windows.Forms.Button btnAddProduct;
        private System.Windows.Forms.LinkLabel linkCategory;
        private System.Windows.Forms.LinkLabel linkSupplier;
        private System.Windows.Forms.LinkLabel linkProduct;
        private System.Windows.Forms.LinkLabel linkOrder;
    }
}