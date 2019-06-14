namespace Q2
{
    partial class CorporationListForm
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
            this.gvCorporation = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gvCorporation)).BeginInit();
            this.SuspendLayout();
            // 
            // gvCorporation
            // 
            this.gvCorporation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvCorporation.Location = new System.Drawing.Point(4, 54);
            this.gvCorporation.Name = "gvCorporation";
            this.gvCorporation.Size = new System.Drawing.Size(567, 244);
            this.gvCorporation.TabIndex = 0;
            this.gvCorporation.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvCorporation_CellContentClick);
            // 
            // CorporationListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 304);
            this.Controls.Add(this.gvCorporation);
            this.Name = "CorporationListForm";
            this.Text = "CorporationListForm";
            ((System.ComponentModel.ISupportInitialize)(this.gvCorporation)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gvCorporation;
    }
}