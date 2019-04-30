using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COMPX323_App
{
    class Customer
    {
        private int customerID;
        private int cartID;
        //private List<Product> cart;
        
        public int CustomerID { get => customerID; }
        public int CartID { get => cartID; }
        //public List<Product> Cart { get => cart; set => cart = value; }
        
        public Customer(int customerID, int cartID)
        {
            this.customerID = customerID;
            this.cartID = cartID;
        }
        /*
        public void buildCart()
        {
            try
            {
                Oracle.getProducts(customerID, cartID, cart);
            }
            catch(Exception e)
            {
                MessageBox.Show("Error building cart in Customer.cs : " + e.ToString());
            }
        }
        */
    }
}
