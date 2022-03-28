using System;
using System.Collections.Generic;

namespace ElectroShopApi.Domain.Payment
{
    public record PaymentRequirment(
        double Amount,
        List<PaymentOptionType> AvailablePaymentOptions
    );
}
