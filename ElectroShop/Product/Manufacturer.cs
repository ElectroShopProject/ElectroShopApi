using System;
namespace ElectroShop
{
    public record Manufacturer(String Name, String Country)
    {
        public Guid Id { init; get; } = Guid.NewGuid();
    }
}
