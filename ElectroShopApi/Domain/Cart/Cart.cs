using System;
using System.Collections.Generic;
using ElectroShopApi.Domain;

namespace ElectroShopApi
{
    public record Cart(List<Product> Products)
    {
        public Guid Id { get; init; } = Guid.NewGuid();
    }
}
