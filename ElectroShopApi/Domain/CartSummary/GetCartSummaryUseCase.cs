using System.Linq;
using ElectroShopApi.Domain.CartSummary;
using ElectroShopApi.Domain.Summary;

namespace ElectroShopApi
{
    public class GetCartSummaryUseCase
    {

        public GetCartSummaryUseCase()
        {
        }

        public static CartSummary Get(Cart cart)
        {
            var countedProducts = GetCountedProductsUseCase.Get(cart.Products);
            var summaryProducts = countedProducts.Select(pair =>
                // Key is a Product
                // Value is a count of the Product
                new SummaryProduct(
                    Id: pair.Key.Id,
                    Name: pair.Key.Name,
                    Category: pair.Key.Category,
                    Manufacturer: pair.Key.Manufacturer,
                    NetPrice: pair.Key.NetPrice * pair.Value, // Price * count
                    GrossPrice: pair.Key.GrossPrice * pair.Value, // Price * count
                    TaxRate: pair.Key.TaxRate,
                    Count: pair.Value
                )
            ).ToList();

            var netTotal = summaryProducts.Sum(product => product.NetPrice);
            var grossTotal = summaryProducts.Sum(product => product.NetPrice);

            return new CartSummary(
                Products: summaryProducts,
                NetTotal: netTotal,
                GrossTotal: grossTotal
            );
        }
    }
}
