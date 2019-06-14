using App.Entity;
using App.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Q2
{
    public partial class CorporationListForm : Form
    {
        public CorporationListForm()
        {
            InitializeComponent();
            Init();
        }

        public void Init()
        {
            gvCorporation.AutoGenerateColumns = false;
            gvCorporation.DataSource = Corporation.All();

            gvCorporation.Columns.Add(textGridViewColumn("Corporation No", "corp_no"));
            gvCorporation.Columns.Add(textGridViewColumn("Corporation Name", "corp_name"));
            gvCorporation.Columns.Add(textGridViewColumn("ExprDate", "date_format"));
            gvCorporation.Columns.Add(textGridViewColumn("Region Name", "RegionName"));

            gvCorporation.Columns.Add(buttonGridViewColumn("Edit", "Edit"));
        }

        public DataGridViewTextBoxColumn textGridViewColumn(
            string header_name,
            string data_text_field)
        {
            DataGridViewTextBoxColumn txt = new DataGridViewTextBoxColumn();
            txt.HeaderText = header_name;
            txt.Name = data_text_field;
            txt.DataPropertyName = data_text_field;
            return txt;
        }

        public DataGridViewButtonColumn buttonGridViewColumn(string headerText, string textName)
        {
            DataGridViewButtonColumn gridView = new DataGridViewButtonColumn();
            gridView.Name = headerText;
            gridView.Text = textName;
            gridView.UseColumnTextForButtonValue = true;
            return gridView;
        }

        private void gvCorporation_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gvCorporation.Columns[e.ColumnIndex].Name.Equals("Edit"))
            {
                int corp_no = Convert.ToInt32(gvCorporation.Rows[e.RowIndex].Cells[0].Value);
                frmEdit edit = new frmEdit(corp_no);
                edit.ShowDialog();
                if (edit.Sucess)
                {
                    MessageBox.Show("Edit sucessful");
                    Init();
                }
            }
        }
    }
}
