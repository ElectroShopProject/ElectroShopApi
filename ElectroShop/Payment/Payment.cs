using System;
namespace ElectroShop
{
    public record Payment(double Amount, PaymentStatus PaymentStatus, PaymentOptionType Type)
    {
        public Guid Id { get; init; } = Guid.NewGuid();
    }
}
