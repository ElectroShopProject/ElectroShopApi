using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ElectroShop;

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
            return GetCartUseCase.Get(Carts.Values(), id);
        }

        public Cart CreateCart(Guid userId)
        {
            var user = _userService.GetUser(userId);
            var newCart = CreateCartUseCase.Create(Carts.Values(), user);
            Carts.Add(newCart);
            return newCart;
        }

        public List<Product> GetProducts(Guid id)
        {
            return GetCart(id)?.Products ?? new List<Product>();
        }

        public async Task<Cart> AddProduct(Guid cartId, Guid productId)
        {
            var cart = GetCart(cartId);
            if (cart == null)
            {
                throw new NullReferenceException();
            }

            var product = await _productService.GetProduct(productId);
            var updatedCart = AddProductToCartUseCase.Add(cart, product);
            return updatedCart;
        }

        public async Task<Cart> RemoveProduct(Guid cartId, Guid productId)
        {
            var cart = GetCart(cartId);
            if (cart == null)
            {
                throw new NullReferenceException();
            }

            var product = await _productService.GetProduct(productId);
            var updatedCart = RemoveProductFromCartUseCase.Remove(cart, product);
            return updatedCart;
        }

        public bool DeleteCart(Guid id)
        {
            var elementsRemoved = Carts.RemoveWhere((cart) => cart.Id == id);
            return elementsRemoved > 0;
        }
    }
}
