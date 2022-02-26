using System;
namespace ElectroShopApi
{
    public record ProductCategory
    {
        public Guid Guid { get; init; }
        public string Name { get; init; }
    }
}
