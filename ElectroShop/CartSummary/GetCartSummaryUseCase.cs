using System.Linq;

namespace ElectroShop
{
    public class GetCartSummaryUseCase
    {
        public static CartSummary Get(Cart cart)
        {
            var countedProducts = GetCountedProductsUseCase.Get(cart.Products);
            var summaryProducts = countedProducts.Select(pair =>
                new SummaryProduct(
                    Id: pair.Key.Id,
                    Name: pair.Key.Name,
                    Category: pair.Key.Category,
                    Manufacturer: pair.Key.Manufacturer,
                    NetPrice: pair.Key.NetPrice,
                    GrossPrice: pair.Key.GrossPrice,
                    TaxRate: pair.Key.TaxRate,
                    Count: pair.Value
                )
            ).ToList();

            var netTotal = summaryProducts.Sum(product => product.NetPrice * product.Count);
            var grossTotal = summaryProducts.Sum(product => product.GrossPrice * product.Count);

            return new CartSummary(
                Products: summaryProducts,
                NetTotal: netTotal,
                GrossTotal: grossTotal
            );
        }
    }
}
