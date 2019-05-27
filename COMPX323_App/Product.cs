using System;

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

        public Product(Product product)
        {
            this.productID = product.productID;
            this.name = product.name;
            this.price = product.price;
            this.quantity = product.quantity;
            this.description = product.description;
        }

        public int ProductID { get => productID; }
        public string Name { get => name; }
        public decimal Price { get => price; }
        public int Quantity { get => quantity; }
        public string Description { get => description; }
        public string toString()
        {
            return productID.ToString().PadLeft(2).PadRight(7)
                + name.PadLeft(25)
                + price.ToString("C2").PadLeft(20)
                + quantity.ToString().PadLeft(5)
                + (price * quantity).ToString("C2").PadLeft(5);
        }
        public int removeOneProductQuantity()
        {
            return quantity--;
        }
    }
}
