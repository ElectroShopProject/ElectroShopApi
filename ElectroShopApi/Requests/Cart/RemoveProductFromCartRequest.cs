using System;
namespace ElectroShopApi
{
    public record RemoveProductFromCartRequest(Guid cartId, Guid productId);
}
