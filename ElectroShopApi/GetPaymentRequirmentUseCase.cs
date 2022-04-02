using System;
using System.Collections.Generic;
using System.Linq;
using ElectroShopApi.Domain.Payment;
using ElectroShopApi.Domain.Summary;

namespace ElectroShopApi
{
    public class GetPaymentRequirmentUseCase
    {
        public GetPaymentRequirmentUseCase()
        {
        }

        public static PaymentRequirment Get(
            CartSummary summary,
            List<PaymentOption> paymentOptions
        )
        {
            var availableOptions = paymentOptions
                .Where(option => option.IsAvailable)
                .Select(optionType => optionType.Type)
                .ToList();

            return new PaymentRequirment(
                Amount: summary.GrossTotal,
                availableOptions
           );
        }
    }
}
