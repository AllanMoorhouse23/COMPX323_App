﻿using System.Collections.Generic;
using System.Linq;

namespace COMPX323_App
{
    class Customer
    {
        private readonly int customerID;
        private int cartID;
        private List<Product> cart;
        
        public Customer(int customerID)
        {
            this.customerID = customerID;
            cart = new List<Product>();
        }

        public int CustomerID => customerID;
        public int CartID { get => cartID; set => cartID = value; }
        internal List<Product> Cart { get => cart; set => cart = value; }

        public void addProductToCart(Product product)
        {
            cart.Add(product);
        }
        public int getCartSize()
        {
            return cart.Count();
        }
        public Product getCartItem(int index)
        {
            return cart.ElementAt(index);
        }
    }
}
