using System;
namespace ElectroShopApi
{
    public record AddProductToCartRequest(Guid cartId, Guid productId);
}
