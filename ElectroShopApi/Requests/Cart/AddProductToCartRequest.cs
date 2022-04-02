using System;
namespace ElectroShopApi
{
    public record AddProductToCartRequest(Guid CartId, Guid ProductId);
}
