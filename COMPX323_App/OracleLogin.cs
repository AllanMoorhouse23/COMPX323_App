using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace COMPX323_App
{
    public partial class OracleLogin : Form
    {
        public OracleLogin()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            string dbusername = "SYSTEM";
            string dbpassword = "";
            int id;

            string firstName;
            string lastName;

            string email = emai_input.Text;
            var password = password_input.Text;

            //MessageBox.Show(email+','+password);
            string oradb = "Data Source=oracle.cms.waikato.ac.nz:1521/teaching.cms.waikato.ac.nz;User Id=COMPX323_12;Password=TmBwyp7P5n;";
            //string oradb = "Data Source=localhost/orcl;User Id="+dbusername+";Password="+dbpassword+";";
            OracleConnection conn = new OracleConnection(oradb);  // C#
            conn.Open();

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select * from customer where email = '"+email+"' and customer_password = '"+password+"'";
            cmd.CommandType = CommandType.Text;
            OracleDataReader dr = cmd.ExecuteReader();

            //some error checking if null returned email or password incorrect otherwise login and show some information
            if (dr.Read())
            {
                id = dr.GetInt32(0);
                firstName = dr.GetString(1);
                lastName = dr.GetString(2);
                MessageBox.Show("Login Succesful, Welcome:\t"+firstName+" "+lastName+" ID: "+id);
                label1.Text = "Logged in as: "+firstName+" "+lastName;
                
                this.Hide();
                var oracleHomepage = new OracleHomepage(id);
                oracleHomepage.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Email or password incorrect, please try again");
            }
        }
    }
}
