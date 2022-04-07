using System;
using System.Collections.Generic;

namespace ElectroShop
{
    public record Cart(User User, List<Product> Products)
    {
        public Guid Id { get; init; } = Guid.NewGuid();
    }
}
