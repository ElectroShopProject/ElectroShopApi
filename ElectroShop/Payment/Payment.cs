using System;
namespace ElectroShop
{
    public record Payment(double Amount, PaymentStatus PaymentStatus, PaymentOptionType Type);
}
