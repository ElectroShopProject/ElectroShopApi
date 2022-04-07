using System;
using System.Collections.Generic;

namespace ElectroShop
{
    public record Order(Guid CartId, User User, Payment Payment, List<Product> Products)
    {
        public Guid Id { get; init; } = Guid.NewGuid();
    }
}
