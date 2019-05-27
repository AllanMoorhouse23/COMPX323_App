using Oracle.ManagedDataAccess.Client;
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
    public partial class OracleBrowseProducts : Form
    {
        private int customerID;
        private int cartID;
        private int currentPageIndex = 0;
        private List<Product> currentPage;
        private List<List<Product>> pages = new List<List<Product>>();
        public OracleBrowseProducts(int customerID)
        {
            InitializeComponent();
            this.customerID = customerID;
            // Get Cart ID
            string oradb = "Data Source=localhost/ORCL;User Id=SYSTEM;Password=TmBwyp7P5n;";
            //string oradb = "Data Source=oracle.cms.waikato.ac.nz:1521/teaching.cms.waikato.ac.nz;User Id=COMPX323_12;Password=TmBwyp7P5n;";
            OracleConnection conn = new OracleConnection(oradb);
            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT cart.CART_ID " +
                "FROM CUSTOMER customer, CART cart " +
                "WHERE customer.CUSTOMER_ID = '" + customerID + "' " +
                "AND customer.CUSTOMER_ID = cart.CUSTOMER_ID";
            OracleDataReader dr = cmd.ExecuteReader();
            dr.Read();
            cartID = dr.GetInt32(0);

            //Get Products
            cmd.CommandText = "SELECT PRODUCT_ID, PRODUCT_NAME, PRICE, STOCK_COUNT, PRODUCT_DESCRIPTION FROM PRODUCT";
            dr = cmd.ExecuteReader();
            List<Product> page = new List<Product>();
            while (dr.Read())
            {
                page.Add(new Product(dr.GetInt32(0),
                                     dr.GetString(1),
                                     dr.GetDecimal(2),
                                     dr.GetInt32(3),
                                     dr.GetString(4)));

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
            conn.Close();
            conn.Dispose();

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

        private void executeQuery(String query)
        {
            // Execute Oracle database query
            string oradb = "Data Source=localhost/ORCL;User Id=SYSTEM;Password=TmBwyp7P5n;";
            //string oradb = "Data Source=oracle.cms.waikato.ac.nz:1521/teaching.cms.waikato.ac.nz;User Id=COMPX323_12;Password=TmBwyp7P5n;";
            OracleConnection conn = new OracleConnection(oradb);
            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();
        }

        // 1
        private void Button1_Click(object sender, EventArgs e)
        {
            if (int.Parse(labelQuantity1.Text) == 0)
            {
                MessageBox.Show("Out of Stock");
                return;
            }
            int productID = int.Parse(labelID1.Text);
            //Remove from the form
            labelQuantity1.Text = (int.Parse(labelQuantity1.Text) - 1).ToString();
            // Remove from memory
            currentPage.Find(product => product.ProductID == int.Parse(labelID1.Text)).removeOneProductQuantity();
            
            // Update quantity on Oracle database
            String query = "UPDATE contains " +
                "SET quantity = quantity + 1 " +
                "WHERE cart_id = '" + cartID + "' " +
                "AND product_id = '" + productID + "'";
            executeQuery(query);
            query = "UPDATE product " +
                "SET stock_count = stock_count - 1 " +
                "WHERE product_id = '" + productID + "'";
            executeQuery(query);
        }

        // 2
        private void Button3_Click(object sender, EventArgs e)
        {
            if (int.Parse(labelQuantity2.Text) == 0)
            {
                MessageBox.Show("Out of Stock");
                return;
            }
            int productID = int.Parse(labelID2.Text);
            //Remove from the form
            labelQuantity2.Text = (int.Parse(labelQuantity2.Text) - 1).ToString();
            // Remove from memory
            currentPage.Find(product => product.ProductID == int.Parse(labelID2.Text)).removeOneProductQuantity();

            // Update quantity on Oracle database
            String query = "UPDATE contains " +
                "SET quantity = quantity + 1 " +
                "WHERE cart_id = '" + cartID + "' " +
                "AND product_id = '" + productID + "'";
            executeQuery(query);
            query = "UPDATE product " +
                "SET stock_count = stock_count - 1 " +
                "WHERE product_id = '" + productID + "'";
            executeQuery(query);
        }

        // 3
        private void Button4_Click(object sender, EventArgs e)
        {
            if (int.Parse(labelQuantity3.Text) == 0)
            {
                MessageBox.Show("Out of Stock");
                return;
            }
            int productID = int.Parse(labelID3.Text);
            //Remove from the form
            labelQuantity3.Text = (int.Parse(labelQuantity3.Text) - 1).ToString();
            // Remove from memory
            currentPage.Find(product => product.ProductID == int.Parse(labelID3.Text)).removeOneProductQuantity();

            // Update quantity on Oracle database
            String query = "UPDATE contains " +
                "SET quantity = quantity + 1 " +
                "WHERE cart_id = '" + cartID + "' " +
                "AND product_id = '" + productID + "'";
            executeQuery(query);
            query = "UPDATE product " +
                "SET stock_count = stock_count - 1 " +
                "WHERE product_id = '" + productID + "'";
            executeQuery(query);
        }

        // 4
        private void Button5_Click(object sender, EventArgs e)
        {
            if (int.Parse(labelQuantity4.Text) == 0)
            {
                MessageBox.Show("Out of Stock");
                return;
            }
            int productID = int.Parse(labelID4.Text);
            //Remove from the form
            labelQuantity4.Text = (int.Parse(labelQuantity4.Text) - 1).ToString();
            // Remove from memory
            currentPage.Find(product => product.ProductID == int.Parse(labelID4.Text)).removeOneProductQuantity();

            // Update quantity on Oracle database
            String query = "UPDATE contains " +
                "SET quantity = quantity + 1 " +
                "WHERE cart_id = '" + cartID + "' " +
                "AND product_id = '" + productID + "'";
            executeQuery(query);
            query = "UPDATE product " +
                "SET stock_count = stock_count - 1 " +
                "WHERE product_id = '" + productID + "'";
            executeQuery(query);
        }

        // 5
        private void Button6_Click(object sender, EventArgs e)
        {
            if (int.Parse(labelQuantity5.Text) == 0)
            {
                MessageBox.Show("Out of Stock");
                return;
            }
            int productID = int.Parse(labelID5.Text);
            //Remove from the form
            labelQuantity5.Text = (int.Parse(labelQuantity5.Text) - 1).ToString();
            // Remove from memory
            currentPage.Find(product => product.ProductID == int.Parse(labelID5.Text)).removeOneProductQuantity();

            // Update quantity on Oracle database
            String query = "UPDATE contains " +
                "SET quantity = quantity + 1 " +
                "WHERE cart_id = '" + cartID + "' " +
                "AND product_id = '" + productID + "'";
            executeQuery(query);
            query = "UPDATE product " +
                "SET stock_count = stock_count - 1 " +
                "WHERE product_id = '" + productID + "'";
            executeQuery(query);
        }

        // 6
        private void Button7_Click(object sender, EventArgs e)
        {
            if (int.Parse(labelQuantity6.Text) == 0)
            {
                MessageBox.Show("Out of Stock");
                return;
            }
            int productID = int.Parse(labelID6.Text);
            //Remove from the form
            labelQuantity6.Text = (int.Parse(labelQuantity6.Text) - 1).ToString();
            // Remove from memory
            currentPage.Find(product => product.ProductID == int.Parse(labelID6.Text)).removeOneProductQuantity();

            // Update quantity on Oracle database
            String query = "UPDATE contains " +
                "SET quantity = quantity + 1 " +
                "WHERE cart_id = '" + cartID + "' " +
                "AND product_id = '" + productID + "'";
            executeQuery(query);
            query = "UPDATE product " +
                "SET stock_count = stock_count - 1 " +
                "WHERE product_id = '" + productID + "'";
            executeQuery(query);
        }

        // View cart
        private void Button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            OracleHomepage oracleHomepage = new OracleHomepage(customerID);
            oracleHomepage.ShowDialog();
            this.Close();
        }
    }
}
