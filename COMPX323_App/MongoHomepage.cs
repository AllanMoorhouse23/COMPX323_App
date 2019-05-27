using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoDB.Driver;

namespace COMPX323_App
{
    public partial class MongoHomepage : Form
    {
        private int customerID;
        private int currentPageIndex = 0;
        private List<Product> currentPage;
        private List<List<Product>> pages = new List<List<Product>>();

        public MongoHomepage(int customerID)
        {
            InitializeComponent();
            this.customerID = customerID;
            // Get Connection
            var connString = "mongodb://localhost:27017";
            MongoClient client = new MongoClient(connString);
            IMongoDatabase db = client.GetDatabase("Compx323-12");

            // Get Customer
            var customerCollection = db.GetCollection<MongoCustomer>("customers");
            var customerList = customerCollection.Find(customer => customer.id == customerID)
                .Limit(1)
                .ToListAsync()
                .Result;

            if (customerList.Count == 0)
            {
                //Console.WriteLine("ERROR customer not found with customerID: " + customerID);
                this.Close();
            }
            else
            {
                foreach (var customer in customerList)
                {
                    //Console.WriteLine("Successfully found customer: " + customer.fname + " " + customer.lname + ", with customer id: " + customer.id);
                    var productCollection = db.GetCollection<MongoProducts>("products");
                    List<Product> page = new List<Product>();
                    foreach (var product in customer.products)
                    {
                        // Get the product details with the id
                        var productList = productCollection.Find(p => p.id == product.id)
                            .Limit(1)
                            .ToListAsync()
                            .Result;
                        if (productList.Count == 0)
                        {
                            //Console.WriteLine("ERROR product item not found with productID: " + product.id);
                            this.Close();
                        }
                        foreach (var p in productList)
                        {
                            page.Add(new Product(product.id, p.name, p.price, product.quantity, p.description));
                            if (page.Count == 6)
                            {
                                pages.Add(page);
                                page = new List<Product>();
                            }
                            //this.customer.addProductToCart(new Product(product.id, p.name, p.price, product.quantity, p.description));//***
                            break; // BECAUSE only contains one item
                        }
                    }
                    if (page.Count < 6 && page.Count != 0)
                    {
                        pages.Add(page);
                    }
                    break; // BECAUSE only contains one item
                }
            }
            displayProducts();
            if (pages.Count > 1)
            {
                labelNext.ForeColor = Color.Blue;
            }

        }

        // Back
        private void LabelBack_Click(object sender, EventArgs e)
        {
            if (currentPageIndex > 0)
            {
                currentPageIndex--;
                displayProducts();
                if (currentPageIndex == 0)
                {
                    labelBack.ForeColor = Color.SlateGray;
                }
                else
                {
                    labelBack.ForeColor = Color.Blue;
                }
                labelNext.ForeColor = Color.Blue;
            }
        }

        // Next
        private void LabelNext_Click(object sender, EventArgs e)
        {
            if (currentPageIndex < pages.Count - 1)
            {
                currentPageIndex++;
                displayProducts();
                if (currentPageIndex == pages.Count - 1)
                {
                    labelNext.ForeColor = Color.SlateGray;
                }
                else
                {
                    labelNext.ForeColor = Color.Blue;
                }
                labelBack.ForeColor = Color.Blue;
            }
        }

        private void displayProducts()
        {
            clearLabels();
            currentPage = pages[currentPageIndex];
            int sizeOfList = currentPage.Count;
            if (sizeOfList >= 1)
            {
                // Product 1
                Product product = currentPage[0];
                labelID1.Text = product.ProductID.ToString();
                labelName1.Text = product.Name;
                labelQuantity1.Text = product.Quantity.ToString();
                labelQuantity1.Visible = true;
                labelPrice1.Text = product.Price.ToString("C2");
                labelTotal1.Text = (product.Price * product.Quantity).ToString("C2");
            }

            if (sizeOfList >= 2)
            {
                // Product 2
                Product product = currentPage[1];
                labelID2.Text = product.ProductID.ToString();
                labelName2.Text = product.Name;
                labelQuantity2.Text = product.Quantity.ToString();
                labelQuantity2.Visible = true;
                labelPrice2.Text = product.Price.ToString("C2");
                labelTotal2.Text = (product.Price * product.Quantity).ToString("C2");
            }
            if (sizeOfList >= 3)
            {
                // Product 3
                Product product = currentPage[2];
                labelID3.Text = product.ProductID.ToString();
                labelName3.Text = product.Name;
                labelQuantity3.Text = product.Quantity.ToString();
                labelQuantity3.Visible = true;
                labelPrice3.Text = product.Price.ToString("C2");
                labelTotal3.Text = (product.Price * product.Quantity).ToString("C2");
            }
            if (sizeOfList >= 4)
            {
                // Product 4
                Product product = currentPage[3];
                labelID4.Text = product.ProductID.ToString();
                labelName4.Text = product.Name;
                labelQuantity4.Text = product.Quantity.ToString();
                labelQuantity4.Visible = true;
                labelPrice4.Text = product.Price.ToString("C2");
                labelTotal4.Text = (product.Price * product.Quantity).ToString("C2");
            }
            if (sizeOfList >= 5)
            {
                // Product 5
                Product product = currentPage[4];
                labelID5.Text = product.ProductID.ToString();
                labelName5.Text = product.Name;
                labelQuantity5.Text = product.Quantity.ToString();
                labelQuantity5.Visible = true;
                labelPrice5.Text = product.Price.ToString("C2");
                labelTotal5.Text = (product.Price * product.Quantity).ToString("C2");
            }
            if (sizeOfList == 6)
            {
                // Product 6
                Product product = currentPage[5];
                labelID6.Text = product.ProductID.ToString();
                labelName6.Text = product.Name;
                labelQuantity6.Text = product.Quantity.ToString();
                labelQuantity6.Visible = true;
                labelPrice6.Text = product.Price.ToString("C2");
                labelTotal6.Text = (product.Price * product.Quantity).ToString("C2");
            }
        }

        private void clearLabels()
        {
            // Product 1
            labelID1.Text = "";
            labelName1.Text = "";
            labelQuantity1.Text = "";
            labelQuantity1.Visible = false;
            labelPrice1.Text = "";
            labelTotal1.Text = "";
            // Product 2
            labelID2.Text = "";
            labelName2.Text = "";
            labelQuantity2.Text = "";
            labelQuantity2.Visible = false;
            labelPrice2.Text = "";
            labelTotal2.Text = "";
            // Product 3
            labelID3.Text = "";
            labelName3.Text = "";
            labelQuantity3.Text = "";
            labelQuantity3.Visible = false;
            labelPrice3.Text = "";
            labelTotal3.Text = "";
            // Product 4
            labelID4.Text = "";
            labelName4.Text = "";
            labelQuantity4.Text = "";
            labelQuantity4.Visible = false;
            labelPrice4.Text = "";
            labelTotal4.Text = "";
            // Product 5
            labelID5.Text = "";
            labelName5.Text = "";
            labelQuantity5.Text = "";
            labelQuantity5.Visible = false;
            labelPrice5.Text = "";
            labelTotal5.Text = "";
            // Product 6
            labelID6.Text = "";
            labelName6.Text = "";
            labelQuantity6.Text = "";
            labelQuantity6.Visible = false;
            labelPrice6.Text = "";
            labelTotal6.Text = "";
        }

        // Remove the entire product from the list on MongoDB
        private void executeRemoveQuery(int productID, int quantity)
        {
            try
            {
                // Get Connection
                var connString = "mongodb://localhost:27017";
                MongoClient client = new MongoClient(connString);
                IMongoDatabase db = client.GetDatabase("Compx323-12");
                // TODO update product quantity
                var customerCollection = db.GetCollection<MongoCustomer>("customers");
                //var filter = Builders<MongoCustomer>.Filter.Where(x => x.id == customerID && x.products.Any(i => i.id == productID));
                var update = Builders<MongoCustomer>.Update.PullFilter(p => p.products, f => f.id == productID);
                var result = customerCollection.FindOneAndUpdateAsync(p => p.id == customerID, update).Result;
                Console.WriteLine("successfully removed product id: " + productID + " from the list of products with customer id: " + customerID);
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: database remove product failed");
                Console.WriteLine(e.Message);
            }
        }

        // Update the quantity of the product from the list on MongoDB
        private void executeUpdateQuery(int productID, int quantity)
        {
            try
            {
                // Get Connection
                var connString = "mongodb://localhost:27017";
                MongoClient client = new MongoClient(connString);
                IMongoDatabase db = client.GetDatabase("Compx323-12");
                // TODO update product quantity
                var customerCollection = db.GetCollection<MongoCustomer>("customers");
                var filter = Builders<MongoCustomer>.Filter.Where(x => x.id == customerID && x.products.Any(i => i.id == productID));
                var update = Builders<MongoCustomer>.Update.Set(x => x.products[-1].quantity, quantity - 1);
                var result = customerCollection.UpdateOneAsync(filter, update).Result;
                Console.WriteLine("successfully removed 1 item quantity from product id: " + productID + " from the list of products with customer id: " + customerID);
            } catch(Exception e)
            {
                MessageBox.Show("Error: database update product quantity failed");
                Console.WriteLine(e.Message);
            }
            
        }

        private void ButtonRemove1_Click(object sender, EventArgs e)
        {
            int productID = int.Parse(labelID1.Text);
            int currentQuantity = int.Parse(labelQuantity1.Text);
            //Remove from the form
            labelQuantity1.Text = (currentQuantity - 1).ToString();
            // Remove from memory
            if (currentPage.Find(product => product.ProductID == int.Parse(labelID1.Text)).removeOneProductQuantity() == 0 || (currentQuantity - 1) == 0)
            {
                currentPage.Remove(currentPage.Find(product => product.ProductID == int.Parse(labelID1.Text)));
                displayProducts();
                // Remove entire row for product on MongoDB
                executeRemoveQuery(productID, currentQuantity);
            }
            else
            {
                // Update quantity on MongoDB
                executeUpdateQuery(productID, currentQuantity);
            }
        }

        private void ButtonRemove2_Click(object sender, EventArgs e)
        {
            int productID = int.Parse(labelID2.Text);
            int currentQuantity = int.Parse(labelQuantity2.Text);
            //Remove from the form
            labelQuantity2.Text = (currentQuantity - 1).ToString();
            // Remove from memory
            if (currentPage.Find(product => product.ProductID == int.Parse(labelID2.Text)).removeOneProductQuantity() == 0 || (currentQuantity - 1) == 0)
            {
                currentPage.Remove(currentPage.Find(product => product.ProductID == int.Parse(labelID2.Text)));
                displayProducts();
                // Remove entire row for product on MongoDB
                executeRemoveQuery(productID, currentQuantity);
            }
            else
            {
                // Update quantity on MongoDB
                executeUpdateQuery(productID, currentQuantity);
            }
        }

        private void ButtonRemove3_Click(object sender, EventArgs e)
        {
            int productID = int.Parse(labelID3.Text);
            int currentQuantity = int.Parse(labelQuantity3.Text);
            //Remove from the form
            labelQuantity3.Text = (currentQuantity - 1).ToString();
            // Remove from memory
            if (currentPage.Find(product => product.ProductID == int.Parse(labelID3.Text)).removeOneProductQuantity() == 0 || (currentQuantity - 1) == 0)
            {
                currentPage.Remove(currentPage.Find(product => product.ProductID == int.Parse(labelID3.Text)));
                displayProducts();
                // Remove entire row for product on MongoDB
                executeRemoveQuery(productID, currentQuantity);
            }
            else
            {
                // Update quantity on MongoDB
                executeUpdateQuery(productID, currentQuantity);
            }
        }

        private void ButtonRemove4_Click(object sender, EventArgs e)
        {
            int productID = int.Parse(labelID4.Text);
            int currentQuantity = int.Parse(labelQuantity4.Text);
            //Remove from the form
            labelQuantity4.Text = (currentQuantity - 1).ToString();
            // Remove from memory
            if (currentPage.Find(product => product.ProductID == int.Parse(labelID4.Text)).removeOneProductQuantity() == 0 || (currentQuantity - 1) == 0)
            {
                currentPage.Remove(currentPage.Find(product => product.ProductID == int.Parse(labelID4.Text)));
                displayProducts();
                // Remove entire row for product on MongoDB
                executeRemoveQuery(productID, currentQuantity);
            }
            else
            {
                // Update quantity on MongoDB
                executeUpdateQuery(productID, currentQuantity);
            }
        }

        private void ButtonRemove5_Click(object sender, EventArgs e)
        {
            int productID = int.Parse(labelID5.Text);
            int currentQuantity = int.Parse(labelQuantity5.Text);
            //Remove from the form
            labelQuantity5.Text = (currentQuantity - 1).ToString();
            // Remove from memory
            if (currentPage.Find(product => product.ProductID == int.Parse(labelID5.Text)).removeOneProductQuantity() == 0 || (currentQuantity - 1) == 0)
            {
                currentPage.Remove(currentPage.Find(product => product.ProductID == int.Parse(labelID5.Text)));
                displayProducts();
                // Remove entire row for product on MongoDB
                executeRemoveQuery(productID, currentQuantity);
            }
            else
            {
                // Update quantity on MongoDB
                executeUpdateQuery(productID, currentQuantity);
            }
        }

        private void ButtonRemove6_Click(object sender, EventArgs e)
        {
            int productID = int.Parse(labelID6.Text);
            int currentQuantity = int.Parse(labelQuantity6.Text);
            //Remove from the form
            labelQuantity6.Text = (currentQuantity - 1).ToString();
            // Remove from memory
            if (currentPage.Find(product => product.ProductID == int.Parse(labelID6.Text)).removeOneProductQuantity() == 0 || (currentQuantity - 1) == 0)
            {
                currentPage.Remove(currentPage.Find(product => product.ProductID == int.Parse(labelID6.Text)));
                displayProducts();
                // Remove entire row for product on MongoDB
                executeRemoveQuery(productID, currentQuantity);
            }
            else
            {
                // Update quantity on MongoDB
                executeUpdateQuery(productID, currentQuantity);
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            MongoBrowseProducts mongoBrowseProducts = new MongoBrowseProducts(customerID);
            mongoBrowseProducts.ShowDialog();
            this.Close();
        }
    }

    public class MongoCustomer
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
        public MongoCartItem[] products { get; set; }
    }

    public class MongoProducts
    {
        public ObjectId Id { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public decimal price { get; set; }
        public int quantity { get; set; }
        public string description { get; set; }
    }

    public class MongoCartItem
    {
        public ObjectId Id { get; set; }
        public int id { get; set; }
        public int quantity { get; set; }
    }
    
    
}
