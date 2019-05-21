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
    public partial class loginMongo : Form
    {
        public loginMongo()
        {
            InitializeComponent();
        }

        private async void loginButtonMongo_ClickAsync(object sender, EventArgs e)
        {
            //mongoDB connection string
            var connString = "mongodb://localhost:27017";

            //get email and password from user input
            var email = emai_input_mongo.Text;
            var password = password_input_mongo.Text;

            //connect to mongoDB
            MongoClient client = new MongoClient(connString);           

            /*set <filterDefinition> as Bson Find filter (which Find accetps as its same structure - Like Json)
            var builder = Builders<BsonDocument>.Filter;
            var filter = builder.Eq("email", email) & builder.Eq("password", password);
                    
            //use Find Method with Filter Definition set above to search for username and password in database
            await collection.Find(filter)
            .ForEachAsync(doc => Console.WriteLine(doc));*/

            //Get Database and Collection  
            IMongoDatabase db = client.GetDatabase("Compx323-12");
            var collection = db.GetCollection<Customer2>("customers");

            //find customer document from customers collection in mongoDB and convert to list
            var custDoc = collection.Find(customer => customer.email == email && customer.password == password).ToList();
            //.ForEachAsync(customer => test(customer.fname,customer.lname,customer.id));

            //call login method, parse in custDoc list
            login(custDoc);
        }

        public async void login(List<Customer2> customer)
        {
            //if custmer doc list is empty then wrong username or password entered
            if (customer.Count == 0)
            {
                MessageBox.Show("Login details incorrect please check your email and password and try again...");
            }
            else {
                //else iterate over doc item in list and get info + login
                foreach (var item in customer)
                {
                    Console.WriteLine(item.fname);
                    MessageBox.Show("Login Succesful, Welcome:\t" + item.fname + " " + item.lname + " ID: " + item.id);
                }                
            };
        }

        public class Customer2
        {
            public ObjectId Id { get; set; }
            public int id { get; set; }
            public string fname { get; set; }
            public string lname { get; set; }
            public string streetAdr { get; set; }
            public string suburb { get; set; }
            public string city { get; set; }
            public string postcode { get; set; }
            public string phone { get; set; }
            public string email { get; set; }
            public string dob { get; set; }
            public string password { get; set; }
        }

    }

}
