using ElectroShopApi.Domain;

namespace ElectroShopApi
{
    public class GetGrossPriceUseCase
    {
        public static double Get(Product product, TaxRate taxRate)
        {
            var taxAmount = product.NetPrice * taxRate.Percent;
            return product.NetPrice + taxAmount;
        }
    }
}
