using System;
using System.Collections.Generic;
using ElectroShopApi.Domain;
using ElectroShopApi.Domain.User;

namespace ElectroShopApi
{
    public record Cart(User User, List<Product> Products)
    {
        public Guid Id { get; init; } = Guid.NewGuid();
    }
}
