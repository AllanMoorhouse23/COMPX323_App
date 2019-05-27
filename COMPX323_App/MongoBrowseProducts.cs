using MongoDB.Driver;
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
    public partial class MongoBrowseProducts : Form
    {
        private int customerID;
        private int currentPageIndex = 0;
        private List<Product> currentPage;
        private List<List<Product>> pages = new List<List<Product>>();

        public MongoBrowseProducts(int customerID)
        {
            InitializeComponent();
            this.customerID = customerID;
            // Get Connection
            var connString = "mongodb://localhost:27017";
            MongoClient client = new MongoClient(connString);
            IMongoDatabase db = client.GetDatabase("Compx323-12");

            //Console.WriteLine("Successfully found customer: " + customer.fname + " " + customer.lname + ", with customer id: " + customer.id);
            var productCollection = db.GetCollection<MongoProducts>("products");
            var customerList = productCollection.Find(p => true)
                .ToListAsync()
                .Result;
            List<Product> page = new List<Product>();
            foreach (var product in customerList)
            {
                page.Add(new Product(product.id, product.name, product.price, product.quantity, product.description));
                if (page.Count == 6)
                {
                    pages.Add(page);
                    page = new List<Product>();
                }
            }
            if (page.Count < 6 && page.Count != 0)
            {
                pages.Add(page);
            }

            displayProducts();
            if (pages.Count > 1)
            {
                labelNext.ForeColor = Color.Blue;
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            MongoHomepage mongoHomepage = new MongoHomepage(customerID);
            mongoHomepage.ShowDialog();
            this.Close();
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
            // Product 2
            labelID2.Text = "";
            labelName2.Text = "";
            labelQuantity2.Text = "";
            labelQuantity2.Visible = false;
            labelPrice2.Text = "";
            // Product 3
            labelID3.Text = "";
            labelName3.Text = "";
            labelQuantity3.Text = "";
            labelQuantity3.Visible = false;
            labelPrice3.Text = "";
            // Product 4
            labelID4.Text = "";
            labelName4.Text = "";
            labelQuantity4.Text = "";
            labelQuantity4.Visible = false;
            labelPrice4.Text = "";
            // Product 5
            labelID5.Text = "";
            labelName5.Text = "";
            labelQuantity5.Text = "";
            labelQuantity5.Visible = false;
            labelPrice5.Text = "";
            // Product 6
            labelID6.Text = "";
            labelName6.Text = "";
            labelQuantity6.Text = "";
            labelQuantity6.Visible = false;
            labelPrice6.Text = "";
        }

        // Update the quantity of the product from the list on MongoDB
        private void executeUpdateQueryCustomer(int productID, int quantity)
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
                var update = Builders<MongoCustomer>.Update.Set(x => x.products[-1].quantity, quantity + 1);
                var result = customerCollection.UpdateOneAsync(filter, update).Result;
                Console.WriteLine("successfully added 1 item quantity from product id: " + productID + " from the list of products with customer id: " + customerID);
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: database update product quantity failed");
                Console.WriteLine(e.Message);
            }

        }

        // Update the stock count of the product on MongoDB
        private void executeUpdateQueryProduct(int productID, int quantity)
        {
            try
            {
                // Get Connection
                var connString = "mongodb://localhost:27017";
                MongoClient client = new MongoClient(connString);
                IMongoDatabase db = client.GetDatabase("Compx323-12");
                // TODO update product quantity
                var productCollection = db.GetCollection<MongoProducts>("products");
                var filter = Builders<MongoProducts>.Filter.Where(x => x.id == productID);
                var update = Builders<MongoProducts>.Update.Set(x => x.quantity, quantity - 1);
                var result = productCollection.UpdateOneAsync(filter, update).Result;
                Console.WriteLine("successfully removed 1 item quantity from product id: " + productID + " from the stock count");
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: database update product quantity failed");
                Console.WriteLine(e.Message);
            }

        }

        // 1
        private void Button1_Click(object sender, EventArgs e)
        {
            int currentQuantity = int.Parse(labelQuantity1.Text);
            if (currentQuantity == 0)
            {
                MessageBox.Show("Out of Stock");
                return;
            }
            int productID = int.Parse(labelID1.Text);
            //Remove from the form
            labelQuantity1.Text = (currentQuantity - 1).ToString();
            // Remove from memory
            currentPage.Find(product => product.ProductID == productID).removeOneProductQuantity();

            // IF item is on customer list
                // GET customer list item quantity
                // Add 1 to customer list item quantity
            // ELSE add new item to customer list

            executeUpdateQueryCustomer(productID, currentQuantity);
            executeUpdateQueryProduct(productID, currentQuantity);
        }

        // 2
        private void Button3_Click(object sender, EventArgs e)
        {
            int currentQuantity = int.Parse(labelQuantity2.Text);
            if (currentQuantity == 0)
            {
                MessageBox.Show("Out of Stock");
                return;
            }
            int productID = int.Parse(labelID2.Text);
            //Remove from the form
            labelQuantity2.Text = (currentQuantity - 1).ToString();
            // Remove from memory
            currentPage.Find(product => product.ProductID == productID).removeOneProductQuantity();
            executeUpdateQueryCustomer(productID, currentQuantity);
            executeUpdateQueryProduct(productID, currentQuantity);
        }

        // 3
        private void Button4_Click(object sender, EventArgs e)
        {
            int currentQuantity = int.Parse(labelQuantity3.Text);
            if (currentQuantity == 0)
            {
                MessageBox.Show("Out of Stock");
                return;
            }
            int productID = int.Parse(labelID3.Text);
            //Remove from the form
            labelQuantity3.Text = (currentQuantity - 1).ToString();
            // Remove from memory
            currentPage.Find(product => product.ProductID == productID).removeOneProductQuantity();
            executeUpdateQueryCustomer(productID, currentQuantity);
            executeUpdateQueryProduct(productID, currentQuantity);
        }

        // 4
        private void Button5_Click(object sender, EventArgs e)
        {
            int currentQuantity = int.Parse(labelQuantity4.Text);
            if (currentQuantity == 0)
            {
                MessageBox.Show("Out of Stock");
                return;
            }
            int productID = int.Parse(labelID4.Text);
            //Remove from the form
            labelQuantity4.Text = (currentQuantity - 1).ToString();
            // Remove from memory
            currentPage.Find(product => product.ProductID == productID).removeOneProductQuantity();
            executeUpdateQueryCustomer(productID, currentQuantity);
            executeUpdateQueryProduct(productID, currentQuantity);
        }

        // 5
        private void Button6_Click(object sender, EventArgs e)
        {
            int currentQuantity = int.Parse(labelQuantity5.Text);
            if (currentQuantity == 0)
            {
                MessageBox.Show("Out of Stock");
                return;
            }
            int productID = int.Parse(labelID5.Text);
            //Remove from the form
            labelQuantity5.Text = (currentQuantity - 1).ToString();
            // Remove from memory
            currentPage.Find(product => product.ProductID == productID).removeOneProductQuantity();
            executeUpdateQueryCustomer(productID, currentQuantity);
            executeUpdateQueryProduct(productID, currentQuantity);
        }

        // 6
        private void Button7_Click(object sender, EventArgs e)
        {
            int currentQuantity = int.Parse(labelQuantity6.Text);
            if (currentQuantity == 0)
            {
                MessageBox.Show("Out of Stock");
                return;
            }
            int productID = int.Parse(labelID6.Text);
            //Remove from the form
            labelQuantity6.Text = (currentQuantity - 1).ToString();
            // Remove from memory
            currentPage.Find(product => product.ProductID == productID).removeOneProductQuantity();
            executeUpdateQueryCustomer(productID, currentQuantity);
            executeUpdateQueryProduct(productID, currentQuantity);
        }
    }
}
