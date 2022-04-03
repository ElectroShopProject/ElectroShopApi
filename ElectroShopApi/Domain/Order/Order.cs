using System;
using System.Collections.Generic;
using ElectroShopApi.Domain;
using ElectroShopApi.Domain.Payment;
using ElectroShopApi.Domain.User;

namespace ElectroShopApi
{
    public record Order(Guid CartId, User User, Payment Payment, List<Product> Products)
    {
        public Guid Id { get; init; } = Guid.NewGuid();
    }
}
