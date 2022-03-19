using System;
namespace ElectroShopApi
{
    public record ProductCategory(string Name)
    {
        public Guid Id { get; init; } = Guid.NewGuid();
    }
}
