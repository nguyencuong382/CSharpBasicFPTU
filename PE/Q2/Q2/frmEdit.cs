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
    public partial class frmEdit : Form
    {
        Corporation cor;

        public frmEdit(int copr_no)
        {
            InitializeComponent();
            Init(copr_no);
            Sucess = false;
        }

        public void Init(int copr_no)
        {
            cor = Corporation.Get(copr_no);
            this.txtCoprName.Text = cor.corp_name;
            this.txtStreet.Text = cor.street;
            
        }

        public bool validation()
        {
            if(this.txtCoprName.Text.Length < 10)
            {
                return false;
            }

            if (String.IsNullOrEmpty(this.txtStreet.Text.Trim()))
            {
                return false;
            }

            if(DateTime.Today.AddDays(9) > this.dtExpireDate.Value)
            {
                return false;
            }

            return true;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (validation())
            {
                cor.corp_name = this.txtCoprName.Text.Trim();
                cor.street = this.txtStreet.Text.Trim();
                cor.expr_dt = this.dtExpireDate.Value;

                CorporationDAO.Update(cor);

                Sucess = true;
                this.Dispose();
            } else
            {
                MessageBox.Show("Input Error");
            }
        }

        public bool Sucess { get; set; }
    }
}
