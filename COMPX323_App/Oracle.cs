using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace COMPX323_App
{
    class Oracle
    {
        private static OracleConnection connection = new OracleConnection("Data Source=localhost/ORCL;User Id=SYSTEM;Password=TmBwyp7P5n;");
        //private static const OracleConnection conn = new OracleConnection("Data Source=oracle.cms.waikato.ac.nz:1521/teaching.cms.waikato.ac.nz;User Id=COMPX323_12;Password=TmBwyp7P5n;");
        private static OracleCommand command = new OracleCommand();
        private static OracleDataReader dataReader = command.ExecuteReader();

        private static void selectQuery(string query)
        {
            try
            {
                connection.Dispose();
                command.Connection = connection;
                connection.Open();
                command.CommandText = query;
                command.CommandType = CommandType.Text;
                dataReader = command.ExecuteReader();
            }
            catch (Exception e)
            {
                MessageBox.Show("Oracle connection error: " + e.ToString());
            }
        }

        private static void executeQuery(string query)
        {
            try
            {
                command.Connection = connection;
                connection.Open();
                command.CommandText = query;
                command.CommandType = CommandType.Text;
                command.ExecuteNonQuery();
            }
            catch(Exception e)
            {
                MessageBox.Show("Oracle connection error: " + e.ToString());
            }
        }

        public List<Product> getProducts(int customerID, int cartID, List<Product> cart)
        {
            try
            {
                Oracle.selectQuery("select p.product_id, p.product_name, p.price, p.product_description " +
                "               from product p, customer cu, contains co " +
                "               where co.cart_id = " + customerID + ";");
                SortedDictionary<int, int> productCount = new SortedDictionary<int, int>();
                while (dataReader.Read())
                {
                    int productID = int.Parse(dataReader.GetString(0));
                    if (!productCount.ContainsKey(productID))
                    {
                        productCount.Add(productID, 1);
                    }
                    else
                    {
                        productCount[productID] = productCount[productID] + 1;
                    }
                }
                Oracle.selectQuery("select p.product_id, p.product_name, p.price, p.product_description " +
                "               from product p, customer cu, contains co " +
                "               where co.cart_id = " + customerID + ";");
                cart = new List<Product>();
                foreach (KeyValuePair<int, int> product in productCount)
                {
                    dataReader.Read();
                    cart.Add(new Product(product.Key,
                                         dataReader.GetString(1),
                                         product.Value,
                                         int.Parse(dataReader.GetString(2)),
                                         dataReader.GetString(3)));
                }
                connection.Dispose();
                return cart;
            }
            catch (Exception e)
            {
                MessageBox.Show("Error building cart in Oracle.cs : " + e.ToString());
                return null;
            }
        }
    }
}
