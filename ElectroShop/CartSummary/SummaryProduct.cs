using System;
namespace ElectroShop
{
    public record SummaryProduct(
        Guid Id,
        string Name,
        ProductCategory Category,
        Manufacturer Manufacturer,
        double GrossPrice,
        double NetPrice,
        TaxRate TaxRate,
        int Count
    );
}
