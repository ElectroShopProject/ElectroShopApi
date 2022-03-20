using System;
using System.Collections.Generic;
using ElectroShopApi.Domain;
using ElectroShopApi.Domain.User;

// TODO Resolve problem if use objects for use cases or only id as ref!

#nullable enable
namespace ElectroShopApi.Services
{
    public class CartService
    {
        // In future replace with repository
        private readonly List<Cart> Carts = new List<Cart>();

        public CartService() { }

        public Cart? GetCart(Guid id)
        {
            return GetCartUseCase.Call(Carts, id);
        }

        public Cart CreateCart(User user)
        {
            return CreateCartUseCase.Call(Carts, user);
        }

        public bool AddProduct(Product Product)
        {
            try
            {

                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
