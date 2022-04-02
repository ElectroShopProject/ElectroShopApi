using System;
namespace ElectroShopApi
{
    public record PaymentOption(PaymentOptionType Type, bool IsAvailable)
    {
        public Guid Id { init; get; } = Guid.NewGuid();
    }
}
