using System;
using System.Collections.Generic;

#nullable enable
namespace ElectroShop
{
    public class CreateCartUseCase
    {
        public static Cart Create(List<Cart> carts, User? user)
        {
            if (user == null)
            {
                throw new NullReferenceException("There is no user with this ID");
            }

            // Don't allow to create a new cart for the same user
            Cart? cart = carts.Find(cart => cart.User.Id == user!.Id);

            if (cart != null)
            {
                return cart;
            }

            return new Cart(User: user, Products: new List<Product>());
        }
    }
}
