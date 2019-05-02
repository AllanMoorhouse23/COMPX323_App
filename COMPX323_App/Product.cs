using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMPX323_App
{
    class Product
    {
        private int productID;
        private string name;
        private decimal price;
        private int quantity;
        private string description;

        public Product(int productID, string name, Decimal price, int quantity, String description)
        {
            this.productID = productID;
            this.name = name;
            this.price = price;
            this.quantity = quantity;
            this.description = description;
        }

        public int ProductID { get => productID; }
        public string Name { get => name; }
        public decimal Price { get => price; }
        public int Quantity { get => quantity; }
        public string Description { get => description; }

        public String toString()
        {
            return name + " " + description + " " + price.ToString() + " " + quantity.ToString();
        }
    }
}
