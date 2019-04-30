using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COMPX323_App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            showForm2();
        }

        private void showForm2() {
            this.Hide();
            var form2 = new Form2(1, 1);
            form2.ShowDialog();
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            label2.Text = "Hello World!";
        }
    }
}
