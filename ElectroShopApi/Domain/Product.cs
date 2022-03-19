using System;
namespace ElectroShopApi.Domain
{
    public record Product(string Name, ProductCategory Category)
    {
        public Guid Id { init; get; } = Guid.NewGuid();
    }
}