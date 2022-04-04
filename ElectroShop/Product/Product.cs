using System;
namespace ElectroShopApi.Domain
{
    public record Product(
        string Name,
        ProductCategory Category,
        Manufacturer Manufacturer,
        double NetPrice,
        double GrossPrice,
        TaxRate TaxRate
    )
    {
        public Guid Id { init; get; } = Guid.NewGuid();
    }
}