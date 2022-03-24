using System;
using System.Collections.Generic;
using ElectroShopApi.Domain;
using ElectroShopApi.Domain.User;

// TODO This is only a temp solution. This should be replaced with Repo
#nullable enable
namespace ElectroShopApi.Services
{
    public class CartService
    {
        private readonly List<Cart> Carts = new();
        private readonly UserService _userService;

        public CartService(UserService userService)
        {
            _userService = userService;
        }

        public Cart? GetCart(Guid id)
        {
            return GetCartUseCase.Call(Carts, id);
        }

        public Cart CreateCart(Guid userId)
        {
            var user =
            return CreateCartUseCase.Call(Carts, userId);
        }

        public bool AddProduct(Cart cart, Guid productId)
        {
            try
            {
                return AddProductToCartUseCase.Call(cart, productId);
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
