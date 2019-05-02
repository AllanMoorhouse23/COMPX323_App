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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            showName();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            label2.Text = "Hello World!";
        }

        private void showName ()
        {
            string oradb = "Data Source=localhost:1521/orcl:; User Id=SYSTEM;Password=Porunga1.ocl;";
            string queryString = "select * from customer";

            using (OracleConnection connection = new OracleConnection(oradb))
            {
                OracleCommand command = new OracleCommand(queryString, connection);
                connection.Open();
                using (OracleDataReader reader = command.ExecuteReader())
                {
                    // Always call Read before accessing data.
                    while (reader.Read())
                    {
                        label1.Text = ("ID: " + reader.GetInt32(0) + "\nFirst Name: " + reader.GetString(1) + "\nLast Name: " + reader.GetString(2));
                    }
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Console.WriteLine(e);
        }
    }
}
