using System;
namespace ElectroShop
{
    public record User(string Name)
    {
        public Guid Id { get; init; } = Guid.NewGuid();
    }
}