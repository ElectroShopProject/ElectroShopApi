using System;
namespace ElectroShopApi
{
    public record Manufacturer(String Name, String Country)
    {
        public Guid Id { init; get; } = Guid.NewGuid();
    }
}
