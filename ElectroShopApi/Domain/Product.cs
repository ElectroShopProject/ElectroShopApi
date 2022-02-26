using System;
namespace ElectroShopApi.Domain
{
    public record Product
    {
        public Guid Guid { get; init; }
        public string Name { get; init; }
        public ProductCategory Category { get; init; }
    }
}
