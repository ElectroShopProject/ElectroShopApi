using System;
using System.Collections.Generic;
using System.Linq;

#nullable enable
namespace ElectroShop
{
    public class GetProductUseCase
    {
        public static Product? Get(List<Product> products, Guid productId)
        {
            return products.First(product => product.Id == productId);
        }
    }
}
