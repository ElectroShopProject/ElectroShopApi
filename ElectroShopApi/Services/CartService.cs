using System;
using System.Collections.Generic;
using ElectroShopApi.Domain;

namespace ElectroShopApi.Services
{
    public class CartService
    {
        private Cart CurrentCart = new Cart(Products: new List<Product>());

        public CartService() { }

        public Cart GetCart(Guid Guid)
        {
            return CurrentCart;
        }

        public bool AddProduct(Product Product)
        {
            try
            {
                var currentProducts = CurrentCart.Products;
                currentProducts.Add(Product);
                CurrentCart = CurrentCart with { Products = currentProducts };
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
