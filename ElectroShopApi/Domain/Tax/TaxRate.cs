using System;
namespace ElectroShopApi
{

    public record TaxRate(ProductCategory Category, double Percent)
    {
        public const double DefaultVatTaxPercent = 0.23;
        public static TaxRate DefaultTax = new(
            Category: ProductCategory.Others,
            Percent: DefaultVatTaxPercent
        );
    }
}
