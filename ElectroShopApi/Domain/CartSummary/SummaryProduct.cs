using System;
namespace ElectroShopApi.Domain.CartSummary
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
