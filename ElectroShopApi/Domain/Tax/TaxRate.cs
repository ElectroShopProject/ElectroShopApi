using System;
namespace ElectroShopApi
{

    public record TaxRate(ProductCategory Category, double Amount)
    {
        public const double DefaultVatTaxAmount = 23;
        public static TaxRate DefaultTax = new(
            Category: ProductCategory.Others,
            Amount: DefaultVatTaxAmount
        );
    }
}
