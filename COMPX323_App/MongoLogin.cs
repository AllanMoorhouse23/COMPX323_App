using System;
using System.Windows.Forms;
using MongoDB.Driver;

namespace COMPX323_App
{
    public partial class MongoLogin : Form
    {
        public MongoLogin()
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
            var collection = db.GetCollection<MongoCustomer>("customers");

            //find customer document from customers collection in mongoDB and convert to list
            var custDoc = collection
                .Find(customer => customer.email == email && customer.password == password)
                .Limit(1)
                .ToListAsync()
                .Result;

            //if custmer doc list is empty then wrong username or password entered
            if (custDoc.Count == 0)
            {
                MessageBox.Show("Login details incorrect please check your email and password and try again...");
            }
            else
            {
                //else iterate over doc item in list and get info + login
                foreach (var item in custDoc)
                {
                    Console.WriteLine(item.fname);
                    MessageBox.Show("Login Succesful, Welcome:\t" + item.fname + " " + item.lname + " ID: " + item.id);
                    this.Hide();
                    var mongoHomePage = new MongoHomepage(item.id);
                    mongoHomePage.ShowDialog();
                    this.Close();
                }
            }

        }
    }
}
