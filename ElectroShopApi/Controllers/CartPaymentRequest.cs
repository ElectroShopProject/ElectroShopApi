using System;

namespace ElectroShopApi.Controllers
{
    public record CartPaymentRequest(
        Guid CartId,
        Guid PaymentId,
        PaymentOptionType PaymentOptionType
    );
}