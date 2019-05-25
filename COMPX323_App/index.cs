using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace COMPX323_App
{
    public partial class index : Form
    {
        public index()
        {
            InitializeComponent();
        }        

        //method to instantiate instance of login form
        private void openLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            OracleLogin login = new OracleLogin();
            login.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var connString = "mongodb://compx323-12:kLjU3r7NCQVoS3zTsms3@mongodb.cms.waikato.ac.nz:27017";

            MongoClient client = new MongoClient(connString);

            var dbList = client.ListDatabases().ToList();

            Console.WriteLine("The list of databases are :");
            foreach (var item in dbList)
            {
                Console.WriteLine(item);
            }

        }

        private void mongoLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            MongoLogin login = new MongoLogin();
            login.ShowDialog();
            this.Close();
        }
    }
}
