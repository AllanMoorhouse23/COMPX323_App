using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace COMPX323_App
{
    public partial class MongoHomepage : Form
    {
        private List<MongoProducts> products;
        private Customer customer;
        public MongoHomepage(int customerID)
        {
            InitializeComponent();

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
                Console.WriteLine("ERROR customer not found with customerID: " + customerID);
                this.Close();
            }
            else
            {
                foreach (var customer in customerList)
                {
                    Console.WriteLine("Successfully found customer: " + customer.fname + " " + customer.lname + ", with customer id: " + customer.id);
                    // Build customer object
                    this.customer = new Customer(customer.id);
                    var productCollection = db.GetCollection<MongoProducts>("products");
                    if (customerList.Count == 0)
                    {
                        Console.WriteLine("ERROR product list not found with customerID: " + customerID);
                        this.Close();
                    }
                    foreach (var product in customer.products)
                    {
                        // Get the product details with the id
                        var productList = productCollection.Find(p => p.id == product.id)
                            .Limit(1)
                            .ToListAsync()
                            .Result;
                        if (customerList.Count == 0)
                        {
                            Console.WriteLine("ERROR product item not found with productID: " + product.id);
                            this.Close();
                        }
                        foreach (var p in productList)
                        {
                            this.customer.addProductToCart(new Product(product.id, p.name, p.price, product.quantity, p.description));
                            break; // BECAUSE only contains one item
                        }
                    }
                    break; // BECAUSE only contains one item
                }
            }

            //Display Products
            int panelCount = 1;
            foreach (Product product in customer.Cart)
            {
                if (customer.Cart.IndexOf(product) == 0)
                {
                    labelName.Text = product.Name;
                    labelDescription.Text = product.Description;
                    labelPrice.Text = product.Price.ToString("C2");
                    labelQuantity.Text = product.Quantity.ToString();
                    labelTotal.Text = (product.Quantity * product.Price).ToString("C2");
                }
                else
                {
                    Label name = new Label();
                    TextBox description = new TextBox();
                    Label price = new Label();
                    TextBox quantity = new TextBox();
                    Label total = new Label();

                    copyControl(labelName, name);
                    copyControl(labelDescription, description);
                    copyControl(labelPrice, price);
                    copyControl(labelQuantity, quantity);
                    copyControl(labelTotal, total);

                    name.Location = new Point(labelName.Location.X * panelCount, labelName.Location.Y * panelCount);
                    description.Location = new Point(labelDescription.Location.X * panelCount, labelDescription.Location.Y * panelCount);
                    price.Location = new Point(labelPrice.Location.X * panelCount, labelPrice.Location.Y * panelCount);
                    quantity.Location = new Point(labelQuantity.Location.X * panelCount, labelQuantity.Location.Y * panelCount);
                    total.Location = new Point(labelTotal.Location.X * panelCount, labelTotal.Location.Y * panelCount);

                    Panel panel = new Panel();
                    panel.Width = panel1.Width;
                    panel.Height = panel1.Height;
                    int panelHeight = panel1.Height * panelCount;
                    panel.Location = new Point(0, panel1.Height);
                    this.Controls.Add(panel);
                    panelCount++;

                    name.Text = product.Name;
                    description.Text = product.Description;
                    price.Text = product.Price.ToString("C2");
                    quantity.Text = product.Quantity.ToString();
                    total.Text = (product.Quantity * product.Price).ToString("C2");
                }
            }
        }
        // Found online to copy the properties of a control
        //https://stackoverflow.com/questions/3473597/it-is-possible-to-copy-all-the-properties-of-a-certain-control-c-window-forms
        private void copyControl(Control sourceControl, Control targetControl)
        {
            // make sure these are the same
            if (sourceControl.GetType() != targetControl.GetType())
            {
                throw new Exception("Incorrect control types");
            }

            foreach (PropertyInfo sourceProperty in sourceControl.GetType().GetProperties())
            {
                object newValue = sourceProperty.GetValue(sourceControl, null);

                MethodInfo mi = sourceProperty.GetSetMethod(true);
                if (mi != null)
                {
                    sourceProperty.SetValue(targetControl, newValue, null);
                }
            }
        }
    }
}
