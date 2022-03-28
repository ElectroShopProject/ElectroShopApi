using System;
using System.Collections.Generic;
using System.Linq;
using ElectroShopApi.Domain;

namespace ElectroShopApi
{
    public class GetGrossPriceUseCase
    {
        public GetGrossPriceUseCase()
        {
        }

        public static double Get(Product product, TaxRate taxRate)
        {
            var taxAmount = product.NetPrice * taxRate.Amount;
            return product.NetPrice + taxAmount;
        }
    }
}
