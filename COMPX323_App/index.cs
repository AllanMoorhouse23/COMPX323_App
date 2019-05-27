using System;
using System.Data;
using System.Windows.Forms;
using MongoDB.Driver;
using Oracle.ManagedDataAccess.Client;

namespace COMPX323_App
{
    public partial class index : Form
    {
        public index()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Test Oracle Connection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                clearLabel();
                string oradb = "Data Source=localhost/ORCL;User Id=SYSTEM;Password=TmBwyp7P5n;";
                //string oradb = "Data Source=oracle.cms.waikato.ac.nz:1521/teaching.cms.waikato.ac.nz;User Id=COMPX323_12;Password=TmBwyp7P5n;";
                OracleConnection conn = new OracleConnection(oradb);
                conn.Open();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM CUSTOMER";
                OracleDataReader dr = cmd.ExecuteReader();
                if (dr.Read() == true)
                {
                    label4.Text = "Status : Success";
                }
                else
                {
                    label4.Text = "Status : Failed";
                }
            } catch(Exception oracleEx)
            {
                label4.Text = "Status : Failure " + oracleEx.Message;
            }
        }

        /// <summary>
        /// Login Oracle
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            OracleLogin login = new OracleLogin();
            login.ShowDialog();
            this.Close();
        }

        /// <summary>
        /// Test MongoDB Connection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                clearLabel();
                var connString = "mongodb://localhost:27017";
                MongoClient client = new MongoClient(connString);
                IMongoDatabase db = client.GetDatabase("Compx323-12");
                var customerCollection = db.GetCollection<MongoCustomer>("customers");
                var customerList = customerCollection.Find(customer => customer.id == 1)
                    .Limit(1)
                    .ToListAsync()
                    .Result;

                if (customerList.Count == 1)
                {
                    label4.Text = "Status : Success";
                }
                else
                {
                    label4.Text = "Status : Failed";
                }
            } catch(Exception mongoEx)
            {
                label4.Text = "Status : Failure " + mongoEx.Message;
            }
        }

        /// <summary>
        /// Login MongoDB
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mongoLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            MongoLogin login = new MongoLogin();
            login.ShowDialog();
            this.Close();
        }

        private void clearLabel()
        {
            label4.Text = "";
        }

        private void ButtonMongoHome_Click(object sender, EventArgs e)
        {
            this.Hide();
            MongoHomepage home = new MongoHomepage(1);
            home.ShowDialog();
            this.Close();
        }

        private void ButtonOracleHome_Click(object sender, EventArgs e)
        {
            this.Hide();
            OracleHomepage home = new OracleHomepage(1);
            home.ShowDialog();
            this.Close();
        }
    }
}
