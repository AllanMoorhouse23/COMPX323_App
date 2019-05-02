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

namespace COMPX323_App
{

    public partial class Form2 : Form
    {
        private Customer customer;
        public Form2(int customerID)
        {
            InitializeComponent();
            //listBox1.Items.Add("Name".PadRight(20) + "Description".PadLeft(10) + "Price".PadLeft(50) + "Quantity".PadLeft(10));
            customer = new Customer(customerID);

            
            string oradb = "Data Source=localhost/ORCL;User Id=SYSTEM;Password=TmBwyp7P5n;";
            OracleConnection conn = new OracleConnection(oradb);
            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT cart.CART_ID " +
                "FROM CUSTOMER customer, CART cart " +
                "WHERE customer.CUSTOMER_ID = '" + customer.CustomerID + "' " +
                "AND customer.CUSTOMER_ID = cart.CUSTOMER_ID";
            OracleDataReader dr = cmd.ExecuteReader();
            dr.Read();
            customer.CartID = dr.GetInt32(0);

            cmd.CommandText = "SELECT p.PRODUCT_ID, p.PRODUCT_NAME, p.PRICE, co.QUANTITY, p.PRODUCT_DESCRIPTION FROM PRODUCT p, CONTAINS co WHERE co.CART_ID = '" + customer.CartID + "' and p.PRODUCT_ID = co.PRODUCT_ID";
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                customer.Cart.Add(new Product(dr.GetInt32(0),
                                              dr.GetString(1),
                                              dr.GetDecimal(2),
                                              dr.GetInt32(3),
                                              dr.GetString(4)));
            }
            conn.Dispose();

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
