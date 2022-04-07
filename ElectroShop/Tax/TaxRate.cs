using System;

namespace ElectroShop
{
    public record TaxRate(ProductCategory Category, double Percent)
    {
        public Guid Id { init; get; } = Guid.NewGuid();

        public const double DefaultVatTaxPercent = 0.23;
        public static TaxRate DefaultTax = new(
            Category: ProductCategory.Others,
            Percent: DefaultVatTaxPercent
        );
    }
}
