using System;
namespace ElectroShopApi.Domain.Cart
{
    public record CartSession(Guid UserId, Guid CartId)
    {
        public Guid Id { get; init; } = Guid.NewGuid();
    }
}
