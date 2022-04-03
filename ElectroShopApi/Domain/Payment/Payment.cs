using System;
namespace ElectroShopApi.Domain.Payment
{
    public record Payment(double Amount, PaymentStatus PaymentStatus);
}
