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
            var form2 = new Form2(3);
            form2.ShowDialog();
            this.Close();
        }

        //method to instantiate instance of login form
        private void openLogin_Click(object sender, EventArgs e)
        {
            loginForm login = new loginForm();
            login.Show();
        }
    }
}
