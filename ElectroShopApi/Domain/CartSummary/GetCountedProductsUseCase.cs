﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace ElectroShopApi.Domain.CartSummary
{
    public class GetCountedProductsUseCase
    {
        public GetCountedProductsUseCase()
        {
        }

        public static List<KeyValuePair<Product, int>> Get(List<Product> products)
        {
            var countedProducts = products
                .GroupBy(product => product.Id)
                .Select((IGrouping<Guid, Product> group) =>
                {
                    return new KeyValuePair<Product, int>(
                        group.First(),
                        products.Count(product => product.Id == group.Key)
                    );
                });

            return countedProducts.ToList();
        }
    }
}
