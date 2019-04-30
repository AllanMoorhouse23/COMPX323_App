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

    public partial class Form2 : Form
    {
        private const string HEADERS = "Name     Description                     Price       Quantity";
        private static List<Product> cart;
        public Form2(int customerID, int cartID)
        {
            InitializeComponent();
            listBox1.Items.Add(HEADERS);
            Customer customer = new Customer(customerID, cartID);
            cart = new List<Product>();
            Oracle.getProducts(customerID, cartID, cart);
            foreach(Product product in cart)
            {
                listBox1.Items.Add(product.ToString());

            }
        }
    }
}
