using System;
using ElectroShop;

namespace ElectroShopApi.Controllers
{
    public record CartPaymentRequest(
        Guid CartId,
        Guid PaymentId,
        PaymentOptionType PaymentOptionType
    );
}