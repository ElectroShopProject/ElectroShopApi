using System;
using System.Collections.Generic;

namespace ElectroShop
{
    public record PaymentRequirment(
        double Amount,
        List<PaymentOptionType> AvailablePaymentOptions
    );
}
