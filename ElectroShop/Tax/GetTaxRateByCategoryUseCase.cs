using System.Collections.Generic;
using System.Linq;

namespace ElectroShop
{
    public class GetTaxRateByCategoryUseCase
    {
        public static TaxRate Get(List<TaxRate> taxRates, ProductCategory category)
        {
            return taxRates
                .Where(rate => rate.Category == category)
                .DefaultIfEmpty(TaxRate.DefaultTax)
                .First();
        }
    }
}
