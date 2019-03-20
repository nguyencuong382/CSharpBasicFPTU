using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void FormLoad(object sender, EventArgs e)
        {
            Console.WriteLine("Loaded");
        }

        private void Add_Click(object sender, EventArgs e)
        {
            Button newButton = new Button();

            newButton.Size = new System.Drawing.Size(75, 23);

            newButton.Name = "New Button";
            newButton.Text = "New Button";

            this.panelBtns.Controls.Add(newButton);


        }

        private void Reset_Click(object sender, EventArgs e)
        {
            this.panelBtns.Controls.OfType<Button>().ToList().ForEach(btn => btn.Dispose());
        }

        private void Remove_Click(object sender, EventArgs e)
        {
            List<Button> buttons = this.panelBtns.Controls.OfType<Button>().ToList();
            foreach (Button btn in buttons)
            {
                //btn.Click -= new EventHandler(this.b_Click); //It's unnecessary
                this.panelBtns.Controls.Remove(btn);
                btn.Dispose();
                break;
            }
        }

        private void Red_Click(object sender, EventArgs e)
        {
            this.txtArea.ForeColor = Color.Red;
        }

        private void blueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.txtArea.ForeColor = Color.Blue;
        }

        private void greenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.txtArea.ForeColor = Color.Green;
        }

        private void arialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.txtArea.Font = new Font("Arial", 24, FontStyle.Bold);
        }
    }
}
