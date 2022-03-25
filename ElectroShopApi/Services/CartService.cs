using System;
using System.Collections.Generic;

// TODO This is only a temp solution. This should be replaced with Repo
#nullable enable
namespace ElectroShopApi.Services
{
    public class CartService
    {
        private readonly HashSet<Cart> Carts = new();
        private readonly UserService _userService;
        private readonly ProductService _productService;

        public CartService(UserService userService, ProductService productService)
        {
            _userService = userService;
            _productService = productService;
        }

        public Cart? GetCart(Guid id)
        {
            return GetCartUseCase.Call(Carts.Values(), id);
        }

        public Cart CreateCart(Guid userId)
        {
            var user = _userService.GetUser(userId);
            // The set has problem that can contain other carts with the same ID
            var newCart = CreateCartUseCase.Call(Carts.Values(), user);
            Carts.Add(newCart);
            return newCart;
        }

        public bool AddProduct(Cart cart, Guid productId)
        {
            var product = _productService.GetProduct(productId);
            var updatedCart = AddProductToCartUseCase.Call(cart, product);
            return updatedCart.Products.Contains(product);
        }
    }
}
