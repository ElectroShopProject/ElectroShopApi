using System;
using System.Collections.Generic;

#nullable enable
namespace ElectroShop
{
    public class GetProductUseCase
    {
        public static Product? Get(List<Product> products, Guid productId)
        {
            return products.Find(product => product.Id == productId);
        }
    }
}
